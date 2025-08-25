using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCU_Comedor.Models;
using System.Web.Mvc;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing.Imaging;

namespace TCU_Comedor.Controllers
{
    public class ReportesController : Controller
    {
        private readonly ApplicationDbContext BaseDatos = new ApplicationDbContext();

        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult ReporteUsuarios(string formato)
        {
            var usuarios = BaseDatos.Users.ToList();

            if (formato == "pdf")
            {
                // Generar PDF simple
                using (MemoryStream ms = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    doc.Add(new Paragraph("📊 Reporte General de Usuarios"));
                    doc.Add(new Paragraph(" "));
                    PdfPTable tabla = new PdfPTable(2);
                    tabla.AddCell("Usuario");
                    tabla.AddCell("Correo");

                    foreach (var u in usuarios)
                    {
                        tabla.AddCell(u.UserName);
                        tabla.AddCell(u.Email);
                    }

                    doc.Add(tabla);
                    doc.Close();

                    return File(ms.ToArray(), "application/pdf", "ReporteGeneral.pdf");
                }
            }

            return View(usuarios);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult ReporteTendencias(string formato)
        {
            var consultas = BaseDatos.ConsultaServicio.ToList();

            // Agrupar por mes y año
            var tendencias = consultas
                .GroupBy(c => new { c.FechaExperienciaNutricional.Year, c.FechaExperienciaNutricional.Month })
                .Select(g => new
                {
                    Mes = g.Key.Month,
                    Año = g.Key.Year,
                    Cantidad = g.Count()
                })
                .OrderBy(t => t.Año).ThenBy(t => t.Mes)
                .ToList();

            if (formato == "pdf")
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Crear PDF
                    Document doc = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    // Título
                    var pdfFont = new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
                    Paragraph titulo = new Paragraph("📈 Análisis de Tendencias Mensuales", pdfFont);
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);
                    doc.Add(new Paragraph(" "));

                    // Crear gráfico de barras en memoria usando System.Drawing
                    int ancho = 500;
                    int alto = 300;
                    using (Bitmap bmp = new Bitmap(ancho, alto))
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(System.Drawing.Color.White);
                        var brush = new SolidBrush(System.Drawing.Color.SteelBlue);
                        var font = new System.Drawing.Font("Arial", 10);

                        int max = tendencias.Max(t => t.Cantidad);
                        int barWidth = 40;
                        int spacing = 20;
                        int x = 50;

                        foreach (var t in tendencias)
                        {
                            int barHeight = (int)((t.Cantidad / (float)max) * (alto - 50));
                            g.FillRectangle(brush, x, alto - barHeight - 30, barWidth, barHeight);
                            g.DrawString($"{t.Mes}/{t.Año}", font, Brushes.Black, x, alto - 25);
                            g.DrawString(t.Cantidad.ToString(), font, Brushes.Black, x, alto - barHeight - 40);
                            x += barWidth + spacing;
                        }

                        // Guardar imagen en memoria
                        using (MemoryStream imgStream = new MemoryStream())
                        {
                            bmp.Save(imgStream, ImageFormat.Png);
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imgStream.ToArray());
                            img.Alignment = Element.ALIGN_CENTER;
                            doc.Add(img);
                        }
                    }

                    doc.Close();
                    return File(ms.ToArray(), "application/pdf", "ReporteTendencias.pdf");
                }
            }

            return View();
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult ReporteCostos(string formato)
        {
            var proveedores = BaseDatos.Proveedor.Include("CategoriaProveedor").ToList();

            if (formato == "pdf")
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    doc.Add(new Paragraph("💰 Reporte de Costos y Presupuesto"));
                    doc.Add(new Paragraph(" "));
                    PdfPTable tabla = new PdfPTable(3);
                    tabla.AddCell("Proveedor");
                    tabla.AddCell("Categoría");
                    tabla.AddCell("Costo");

                    foreach (var p in proveedores)
                    {
                        tabla.AddCell(p.NombreProveedor);
                        tabla.AddCell(p.CategoriaProveedor.Descripcion);
                        tabla.AddCell(p.Costos);
                    }

                    doc.Add(tabla);
                    doc.Close();

                    return File(ms.ToArray(), "application/pdf", "ReporteCostos.pdf");
                }
            }

            return View(proveedores);
        }

    }
}