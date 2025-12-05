/* Consultas al Modelo Creado para ACME

Created By: Diego Cardona
Creation Date: 12/4/2025

*/

--2.1 Deuda total de Tarjeta de Crédito por Franquicia

	SELECT f.NombreFranquicia,
		   SUM(tc.CupoAprobado - tc.CupoDisponible) AS DeudaTotal
	FROM TarjetaCredito tc
	JOIN Franquicia f ON tc.IdFranquicia = f.IdFranquicia
	GROUP BY f.NombreFranquicia;

--2.2 Cliente con mayor Saldo en Canje

	SELECT TOP 1 p.IdPersona,
		   COALESCE(pn.Nombres + ' ' + pn.Apellidos, pj.RazonSocial) AS Nombre,
		   SUM(c.SaldoEnCanje) AS TotalSaldoEnCanje
	FROM Persona p
	LEFT JOIN PersonaNatural pn ON pn.IdPersona = p.IdPersona
	LEFT JOIN PersonaJuridica pj ON pj.IdPersona = p.IdPersona
	JOIN PersonaTieneRol pr ON pr.IdPersona = p.IdPersona
	JOIN RolPersona r ON r.IdRol = pr.IdRol AND r.NombreRol = 'Cliente'
	JOIN CuentaAhorroTitular cat ON cat.IdPersona = p.IdPersona
	JOIN CuentaAhorro c ON c.NumeroCuenta = cat.NumeroCuenta
	GROUP BY p.IdPersona, pn.Nombres, pn.Apellidos, pj.RazonSocial
	ORDER BY TotalSaldoEnCanje DESC;

--2.3 Cliente con mayor saldo retirado de una Cuenta de Ahorros en un periodo (por rango de fechas)

	DECLARE @FechaInicio DATETIME2 = '2025-01-01',
			@FechaFin    DATETIME2 = '2025-03-31';

	SELECT TOP 1 p.IdPersona,
		   COALESCE(pn.Nombres + ' ' + pn.Apellidos, pj.RazonSocial) AS Nombre,
		   SUM(ma.Monto) AS TotalRetirado
	FROM MovimientoAhorro ma
	JOIN TipoMovimientoAhorro tma ON ma.IdTipoMovimientoAhorro = tma.IdTipoMovimientoAhorro
	JOIN CuentaAhorroTitular cat ON cat.NumeroCuenta = ma.NumeroCuenta
	JOIN Persona p ON p.IdPersona = cat.IdPersona
	LEFT JOIN PersonaNatural pn ON pn.IdPersona = p.IdPersona
	LEFT JOIN PersonaJuridica pj ON pj.IdPersona = p.IdPersona
	WHERE tma.Codigo = 'RETIRO'
	  AND ma.FechaTransaccion BETWEEN @FechaInicio AND @FechaFin
	GROUP BY p.IdPersona, pn.Nombres, pn.Apellidos, pj.RazonSocial
	ORDER BY TotalRetirado DESC;

--2.4 Cuenta de Ahorro con mayor número de titulares
	
	SELECT TOP 1 ca.NumeroCuenta,
       COUNT(cat.IdPersona) AS NumTitulares
	FROM CuentaAhorro ca
	JOIN CuentaAhorroTitular cat ON ca.NumeroCuenta = cat.NumeroCuenta
	GROUP BY ca.NumeroCuenta
	ORDER BY NumTitulares DESC;

--2.5 Saldo Total de todas las cuentas de ahorro de un cliente

	DECLARE @IdPersona INT = 0101;

	SELECT SUM(c.SaldoTotal) AS SaldoTotalCliente
	FROM CuentaAhorroTitular cat
	JOIN CuentaAhorro c ON cat.NumeroCuenta = c.NumeroCuenta
	WHERE cat.IdPersona = @IdPersona;

--2.6 Número de Cuentas de Ahorro activas de clientes extranjeros

	SELECT COUNT(DISTINCT ca.NumeroCuenta) AS CuentasActivasExtranjeros
	FROM CuentaAhorro ca
	JOIN CuentaAhorroTitular cat ON cat.NumeroCuenta = ca.NumeroCuenta
	JOIN PersonaNatural pn ON pn.IdPersona = cat.IdPersona
	JOIN TipoDocumento td ON pn.IdTipoDocumento = td.IdTipoDocumento
	WHERE ca.IdEstado = 1
	  AND td.Codigo IN ('CE','PAS'); 

--2.7 Listado de Accionistas que son clientes con su correspondiente Saldo Total de Deuda de todas las tarjetas > UN MILLÓN

	SELECT p.IdPersona AS IdAccionista,
		   COALESCE(pn.Nombres + ' ' + pn.Apellidos, pj.RazonSocial) AS NombreAccionista,
		   SUM(tc.CupoAprobado - tc.CupoDisponible) AS DeudaTotal
	FROM AccionistaEmpresa ae
	JOIN Persona p ON p.IdPersona = ae.IdAccionista
	JOIN PersonaTieneRol ptr ON ptr.IdPersona = p.IdPersona
	JOIN RolPersona r ON r.IdRol = ptr.IdRol AND r.NombreRol = 'Cliente'
	LEFT JOIN PersonaNatural pn ON pn.IdPersona = p.IdPersona
	LEFT JOIN PersonaJuridica pj ON pj.IdPersona = p.IdPersona
	LEFT JOIN TarjetaCredito tc ON tc.IdPersona = p.IdPersona
	GROUP BY p.IdPersona, pn.Nombres, pn.Apellidos, pj.RazonSocial
	HAVING SUM(COALESCE(tc.CupoAprobado - tc.CupoDisponible, 0)) > 1000000
	ORDER BY DeudaTotal DESC;
