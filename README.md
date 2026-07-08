# Panadería - Sistema de Gestión Comercial

Sistema de gestión para panaderías desarrollado con .NET 8, Blazor WebAssembly, SQL Server y Clean Architecture.
El objetivo del proyecto es centralizar la administración del negocio permitiendo gestionar productos, ventas, stock y métricas
operativas desde una única aplicación web.

# Funcionalidades implementadas
- Productos
- Alta, modificación y eliminación de productos
- Productos vendidos por kilogramo
- Productos vendidos por unidad
- Cálculo automático de precios mediante porcentaje de ganancia
- Gestión de stock actual

# Ventas
- Venta por unidad
- Venta por peso (¼ Kg, ½ Kg, 1 Kg)
- Venta por importe ingresado
- Carrito de compras
- Métodos de pago
- Registro de observaciones
- Actualización automática de stock

# Historial
- Historial completo de ventas
- Detalle de productos vendidos
- Método de pago utilizado
- Totales por venta

# Dashboard
- Recaudación diaria
- Productos vendidos por día
- Ganancias diarias
- Métricas operativas

# Arquitectura
El proyecto está construido utilizando:
- Clean Architecture
- Minimal APIs
- Entity Framework Core
- Specifications Pattern
- Repository Pattern
- DTOs compartidos
- SQL Server

# Tecnologías
- .NET 8
- Blazor WebAssembly
- Entity Framework Core
- SQL Server
- Bootstrap 5
- Minimal APIs
- Clean Architecture


## Capturas
- Inicio
<img width="1365" height="634" alt="Screenshot 2026-07-06 at 12-26-52 Panadería" src="https://github.com/user-attachments/assets/8e857da8-4d1c-4754-bfd0-9218205eec87" />
- Productos
<img width="1365" height="634" alt="Screenshot 2026-07-06 at 12-27-18 Panaderia Blazor" src="https://github.com/user-attachments/assets/68742271-9dca-4e83-b09f-6df5c5a88a2c" />
- Crear Productos
<img width="1365" height="910" alt="Screenshot 2026-07-06 at 12-29-31 Panaderia Blazor" src="https://github.com/user-attachments/assets/08341f5d-a709-4988-99b1-935391370c63" />
- Editar Productos
<img width="1365" height="991" alt="Screenshot 2026-07-06 at 12-29-44 Panaderia Blazor" src="https://github.com/user-attachments/assets/a28086fa-fb03-496a-8de1-0982fe9e5212" />
- Ventas
<img width="1365" height="690" alt="Screenshot 2026-07-06 at 12-27-56 Panaderia Blazor" src="https://github.com/user-attachments/assets/8d2cbf49-7686-4c32-9eba-653077033d45" />
- Modal para confirmar la venta
<img width="1365" height="690" alt="Screenshot 2026-07-06 at 12-28-07 Panaderia Blazor" src="https://github.com/user-attachments/assets/e0642325-fea7-48a7-b654-8f184071f57e" />
- Historial de Ventas
<img width="1365" height="810" alt="Screenshot 2026-07-06 at 12-28-26 Panaderia Blazor" src="https://github.com/user-attachments/assets/7fe585aa-4783-4465-8329-6e83a42cf849" />
- Dashboard
<img width="1365" height="742" alt="Screenshot 2026-07-06 at 12-28-37 Panaderia Blazor" src="https://github.com/user-attachments/assets/2f89fc9b-c5cc-4bc5-b593-ab8f5f0c9635" />
- Dashboard de Ventas
<img width="1365" height="931" alt="Screenshot 2026-07-06 at 12-28-55 Panaderia Blazor" src="https://github.com/user-attachments/assets/19ce6fd6-4d60-457a-baf1-88a66bf67f84" />
- Dashboard de Productos
<img width="1365" height="634" alt="Screenshot 2026-07-06 at 12-36-36 Panaderia Blazor" src="https://github.com/user-attachments/assets/16962522-c10c-4b0c-bd04-bb038b7863f1" />

## Estado actual
**Proyecto en desarrollo activo**.

## Próximas funcionalidades:
- Autenticación JWT
- Login de usuarios
- Gestión de clientes
- Gestión de proveedores
- Reportes avanzados
- Exportación a PDF/Excel
- Alertas de stock bajo
- Búsqueda optimizada desde backend

## Objetivo
Este proyecto fue desarrollado como práctica de arquitectura empresarial en .NET aplicando buenas prácticas de diseño y patrones modernos
de desarrollo.
