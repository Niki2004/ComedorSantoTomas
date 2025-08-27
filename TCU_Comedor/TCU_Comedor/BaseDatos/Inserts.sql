-- Insert de categoriasMenu
INSERT INTO CategoriaMenu (Descripcion) VALUES
('Desayuno'),
('Merienda'),
('Almuerzo');

-- Insert del Menu
-- Lunes 18/08/2025
INSERT INTO Menu (Id_CategoriaMenu, NombreComida, FechaMenu) VALUES
(1, 'Gallo Pinto con Huevo', '2025-08-18'),
(2, 'Frutas Frescas (sandía, piña, mango)', '2025-08-18'),
(3, 'Pollo Guisado con arroz y ensalada', '2025-08-18');

-- Martes 19/08/2025
INSERT INTO Menu (Id_CategoriaMenu, NombreComida, FechaMenu) VALUES
(1, 'Pancakes Integrales con Miel', '2025-08-19'),
(2, 'Galletas de Avena y Jugo Natural', '2025-08-19'),
(3, 'Pescado al Vapor con Puré de Papa', '2025-08-19');

-- Miércoles 20/08/2025
INSERT INTO Menu (Id_CategoriaMenu, NombreComida, FechaMenu) VALUES
(1, 'Avena con Frutas', '2025-08-20'),
(2, 'Yogur con Granola y Miel', '2025-08-20'),
(3, 'Carne en Salsa con Lentejas', '2025-08-20');

-- Jueves 21/08/2025
INSERT INTO Menu (Id_CategoriaMenu, NombreComida, FechaMenu) VALUES
(1, 'Tortillas con Queso Fresco', '2025-08-21'),
(2, 'Palitos de Zanahoria con Dip', '2025-08-21'),
(3, 'Pasta Boloñesa', '2025-08-21');

-- Viernes 22/08/2025
INSERT INTO Menu (Id_CategoriaMenu, NombreComida, FechaMenu) VALUES
(1, 'Cereal Integral con Leche y Frutas', '2025-08-22'),
(2, 'Mini Empanadas de Queso', '2025-08-22'),
(3, 'Arroz con Pollo y Ensalada', '2025-08-22');

-- Insert de ConsultaNutricional
INSERT INTO ConsultaNutricional (Id, Detalles, FechaConsultaNutricional)
VALUES 
('6add60d2-129c-4723-bb7c-ddc4e8007cb6', 'Primera valoración nutricional, revisión de hábitos alimenticios', '2025-08-22'),
('6add60d2-129c-4723-bb7c-ddc4e8007cb6', 'Seguimiento de dieta, ajustes en plan alimenticio', '2025-08-23'),
('6add60d2-129c-4723-bb7c-ddc4e8007cb6', 'Consulta por control de peso y recomendaciones generales', '2025-08-24'),
('6add60d2-129c-4723-bb7c-ddc4e8007cb6', 'Revisión de progreso y nuevas sugerencias', '2025-08-25');

-- Insert de ConsultaServicio
INSERT INTO ConsultaServicio (Id, Detalle, FechaExperienciaNutricional)
VALUES
('1', 'Asesoría sobre alimentación saludable y balanceada', '2025-08-20'),
('2', 'Sesión informativa sobre etiquetado nutricional', '2025-08-21'),
('3', 'Consulta personalizada para control de peso', '2025-08-22'),
('1', 'Charla sobre nutrición deportiva y suplementación', '2025-08-23'),
('4', 'Taller de cocina saludable y práctica de recetas', '2025-08-24');

-- Insert de CategoriaProveedor
INSERT INTO CategoriaProveedor (Descripcion)
VALUES ('Alimentos');

INSERT INTO CategoriaProveedor (Descripcion)
VALUES ('Bebidas');

INSERT INTO CategoriaProveedor (Descripcion)
VALUES ('Limpieza');

INSERT INTO CategoriaProveedor (Descripcion)
VALUES ('Desechables');

INSERT INTO CategoriaProveedor (Descripcion)
VALUES ('Servicios Generales');

-- Insert de Proveedor
INSERT INTO Proveedor (Id_CategoriaProveedor, Costos, NombreProveedor, NumeroProveedor, CorreoProveedor)
VALUES (1, '1000', 'Proveedor ABC', '88881234', 'abc@proveedor.com');

INSERT INTO Proveedor (Id_CategoriaProveedor, Costos, NombreProveedor, NumeroProveedor, CorreoProveedor)
VALUES (2, '500', 'Bebidas XYZ', '88885678', 'xyz@bebidas.com');

INSERT INTO Proveedor (Id_CategoriaProveedor, Costos, NombreProveedor, NumeroProveedor, CorreoProveedor)
VALUES (3, '200', 'Limpieza LMN', '88883456', 'lmn@limpieza.com');

INSERT INTO Proveedor (Id_CategoriaProveedor, Costos, NombreProveedor, NumeroProveedor, CorreoProveedor)
VALUES (4, '350', 'Desechables OPQ', '88887654', 'opq@desechables.com');

INSERT INTO Proveedor (Id_CategoriaProveedor, Costos, NombreProveedor, NumeroProveedor, CorreoProveedor)
VALUES (1, '1500', 'Frutas y Verduras GHI', '88882345', 'ghi@frutasverduras.com');

-- Insert de MonitoreoAlimenticio
INSERT INTO [ComeEduca].[dbo].[MonitoreoAlimenticio] ( [Id_Menu], [Observacion]) 
VALUES (21, 'La comida fue rica en vitamina E');

INSERT INTO [ComeEduca].[dbo].[MonitoreoAlimenticio] ([Id_Menu], [Observacion]) 
VALUES (22,'La comida fue rica en vitamina A');

INSERT INTO [ComeEduca].[dbo].[MonitoreoAlimenticio] ([Id_Menu], [Observacion]) 
VALUES (23,'La comida fue rica en vitamina C');