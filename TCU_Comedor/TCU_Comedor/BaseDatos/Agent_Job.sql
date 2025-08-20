-- Copiar el menú de la semana anterior sumando 7 días
INSERT INTO Menu (Id_CategoriaMenu, NombreComida, FechaMenu)
SELECT Id_CategoriaMenu, NombreComida, DATEADD(DAY, 7, FechaMenu)
FROM Menu
WHERE FechaMenu BETWEEN DATEADD(DAY, -7, CAST(GETDATE() AS DATE)) 
                    AND CAST(GETDATE() AS DATE);
