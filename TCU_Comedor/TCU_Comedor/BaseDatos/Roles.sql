-- Cambiar Roles --

-- Usuario
-- correo: nicolehidalgo437@gmail.com
--Contraseña: 12345678Ni+

INSERT INTO AspNetUserRoles (UserId, RoleId)
SELECT u.Id, r.Id
FROM AspNetUsers u, AspNetRoles r
WHERE u.Email = 'nicolehidalgo437@gmail.com' 
AND r.Name = 'Usuario'

-- Administrador
-- correo: andersonEspinoza437@gmail.com
--Contraseña: 12345678Ae+

INSERT INTO AspNetUserRoles (UserId, RoleId)
SELECT u.Id, r.Id
FROM AspNetUsers u, AspNetRoles r
WHERE u.Email = 'andersonEspinoza437@gmail.com' 
AND r.Name = 'Administrador'

-- Chef
-- correo: susanaChaves437@gmail.com
--Contraseña: 12345678Sc+

INSERT INTO AspNetUserRoles (UserId, RoleId)
SELECT u.Id, r.Id
FROM AspNetUsers u, AspNetRoles r
WHERE u.Email = 'susanaChaves437@gmail.com' 
AND r.Name = 'Chef'