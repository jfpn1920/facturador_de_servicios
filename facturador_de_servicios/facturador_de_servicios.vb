Imports System
Module facturador_de_servicios
    Sub Main(args As String())
        Dim ids(19) As Integer
        Dim clientes(19) As String
        Dim servicios(19) As String
        Dim descripciones(19) As String
        Dim cantidades(19) As Integer
        Dim precios(19) As Double
        Dim subtotales(19) As Double
        Dim impuestos(19) As Double
        Dim totales(19) As Double
        Dim estados(19) As String
        Dim cantidad As Integer = 0
        Dim opcion As Integer
        '--------------------------------------------'
        '--|menu_principal_facturador_de_servicios|--'
        '--------------------------------------------'
        Do
            Console.WriteLine("menu principal facturador de servicios")
            Console.WriteLine("1) Registrar factura")
            Console.WriteLine("2) Editar factura")
            Console.WriteLine("3) Listar facturas")
            Console.WriteLine("4) Buscar factura")
            Console.WriteLine("5) Eliminar factura")
            Console.WriteLine("6) Calcular factura")
            Console.WriteLine("7) Mostrar resumen")
            Console.WriteLine("8) Salir")
            Console.Write("Seleccione una opcion: ")
            opcion = Convert.ToInt32(Console.ReadLine())
            Select Case opcion
                '-----------------------'
                '--|registrar_factura|--'
                '-----------------------'
                Case 1
                    If cantidad >= ids.Length Then
                        Console.WriteLine("No hay espacio para registrar mas facturas.")
                    Else
                        Console.Write("Ingrese el nombre del cliente: ")
                        Dim nuevoCliente As String = Console.ReadLine()
                        If nuevoCliente = "" Then
                            Console.WriteLine("El nombre del cliente no puede estar vacio.")
                        Else
                            Console.Write("Ingrese el nombre del servicio: ")
                            Dim nuevoServicio As String = Console.ReadLine()
                            If nuevoServicio = "" Then
                                Console.WriteLine("El servicio no puede estar vacio.")
                            Else
                                Console.Write("Ingrese la descripcion: ")
                                Dim nuevaDescripcion As String = Console.ReadLine()
                                Console.Write("Ingrese la cantidad: ")
                                Dim nuevaCantidad As Integer = Convert.ToInt32(Console.ReadLine())
                                If nuevaCantidad <= 0 Then
                                    Console.WriteLine("La cantidad debe ser mayor que cero.")
                                Else
                                    Console.Write("Ingrese el precio del servicio: ")
                                    Dim nuevoPrecio As Double = Convert.ToDouble(Console.ReadLine())
                                    If nuevoPrecio < 0 Then
                                        Console.WriteLine("El precio no puede ser negativo.")
                                    Else
                                        Dim nuevoSubtotal As Double = nuevaCantidad * nuevoPrecio
                                        Dim nuevoImpuesto As Double = nuevoSubtotal * 0.19
                                        Dim nuevoTotal As Double = nuevoSubtotal + nuevoImpuesto
                                        ids(cantidad) = cantidad + 1
                                        clientes(cantidad) = nuevoCliente
                                        servicios(cantidad) = nuevoServicio
                                        descripciones(cantidad) = nuevaDescripcion
                                        cantidades(cantidad) = nuevaCantidad
                                        precios(cantidad) = nuevoPrecio
                                        subtotales(cantidad) = nuevoSubtotal
                                        impuestos(cantidad) = nuevoImpuesto
                                        totales(cantidad) = nuevoTotal
                                        estados(cantidad) = "Pendiente"
                                        cantidad += 1
                                        Console.WriteLine("Factura registrada correctamente.")
                                        Console.WriteLine("ID: " & ids(cantidad - 1) & " | Cliente: " & clientes(cantidad - 1) & " | Servicio: " & servicios(cantidad - 1) & " | Descripcion: " & descripciones(cantidad - 1) & " | Cantidad: " & cantidades(cantidad - 1) & " | Precio: $" & precios(cantidad - 1).ToString("N2") & " | Subtotal: $" & subtotales(cantidad - 1).ToString("N2") & " | Impuesto: $" & impuestos(cantidad - 1).ToString("N2") & " | Total: $" & totales(cantidad - 1).ToString("N2") & " | Estado: " & estados(cantidad - 1))
                                    End If
                                End If
                            End If
                        End If
                    End If
                '--------------------'
                '--|editar_factura|--'
                '--------------------'
                Case 2
                    If cantidad = 0 Then
                        Console.WriteLine("No existen facturas registradas.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Cliente: " & clientes(i) & " | Servicio: " & servicios(i) & " | Descripcion: " & descripciones(i) & " | Cantidad: " & cantidades(i) & " | Precio: $" & precios(i).ToString("N2") & " | Subtotal: $" & subtotales(i).ToString("N2") & " | Impuesto: $" & impuestos(i).ToString("N2") & " | Total: $" & totales(i).ToString("N2") & " | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID de la factura a editar: ")
                        Dim idEditar As Integer = Convert.ToInt32(Console.ReadLine())
                        If idEditar >= 1 AndAlso idEditar <= cantidad Then
                            Dim posicion As Integer = idEditar - 1
                            Console.Write("Nuevo cliente: ")
                            Dim nuevoCliente As String = Console.ReadLine()
                            If nuevoCliente = "" Then
                                Console.WriteLine("El nombre del cliente no puede estar vacio.")
                            Else
                                clientes(posicion) = nuevoCliente
                                Console.Write("Nuevo servicio: ")
                                Dim nuevoServicio As String = Console.ReadLine()
                                If nuevoServicio = "" Then
                                    Console.WriteLine("El servicio no puede estar vacio.")
                                Else
                                    servicios(posicion) = nuevoServicio
                                    Console.Write("Nueva descripcion: ")
                                    descripciones(posicion) = Console.ReadLine()
                                    Console.Write("Nueva cantidad: ")
                                    Dim nuevaCantidad As Integer = Convert.ToInt32(Console.ReadLine())
                                    If nuevaCantidad <= 0 Then
                                        Console.WriteLine("La cantidad debe ser mayor que cero.")
                                    Else
                                        Console.Write("Nuevo precio: ")
                                        Dim nuevoPrecio As Double = Convert.ToDouble(Console.ReadLine())
                                        If nuevoPrecio < 0 Then
                                            Console.WriteLine("El precio no puede ser negativo.")
                                        Else
                                            cantidades(posicion) = nuevaCantidad
                                            precios(posicion) = nuevoPrecio
                                            subtotales(posicion) = nuevaCantidad * nuevoPrecio
                                            impuestos(posicion) = subtotales(posicion) * 0.19
                                            totales(posicion) = subtotales(posicion) + impuestos(posicion)
                                            Console.WriteLine("Factura actualizada correctamente.")
                                            Console.WriteLine("ID: " & ids(posicion) & " | Cliente: " & clientes(posicion) & " | Servicio: " & servicios(posicion) & " | Descripcion: " & descripciones(posicion) & " | Cantidad: " & cantidades(posicion) & " | Precio: $" & precios(posicion).ToString("N2") & " | Subtotal: $" & subtotales(posicion).ToString("N2") & " | Impuesto: $" & impuestos(posicion).ToString("N2") & " | Total: $" & totales(posicion).ToString("N2") & " | Estado: " & estados(posicion))
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '---------------------'
                '--|listar_facturas|--'
                '---------------------'
                Case 3
                    If cantidad = 0 Then
                        Console.WriteLine("No existen facturas registradas.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Cliente: " & clientes(i) & " | Servicio: " & servicios(i) & " | Descripcion: " & descripciones(i) & " | Cantidad: " & cantidades(i) & " | Precio: $" & precios(i).ToString("N2") & " | Subtotal: $" & subtotales(i).ToString("N2") & " | Impuesto: $" & impuestos(i).ToString("N2") & " | Total: $" & totales(i).ToString("N2") & " | Estado: " & estados(i))
                        Next
                    End If
                '--------------------'
                '--|buscar_factura|--'
                '--------------------'
                Case 4
                    If cantidad = 0 Then
                        Console.WriteLine("No existen facturas registradas.")
                    Else
                        Console.WriteLine("1) Buscar por ID")
                        Console.WriteLine("2) Buscar por cliente")
                        Console.WriteLine("3) Buscar por servicio")
                        Console.Write("Seleccione una opcion: ")
                        Dim tipoBusqueda As Integer = Convert.ToInt32(Console.ReadLine())
                        If tipoBusqueda = 1 Then
                            Console.Write("Ingrese el ID: ")
                            Dim idBuscar As Integer = Convert.ToInt32(Console.ReadLine())
                            If idBuscar >= 1 AndAlso idBuscar <= cantidad Then
                                Dim posicion As Integer = idBuscar - 1
                                Console.WriteLine("ID: " & ids(posicion) & " | Cliente: " & clientes(posicion) & " | Servicio: " & servicios(posicion) & " | Descripcion: " & descripciones(posicion) & " | Cantidad: " & cantidades(posicion) & " | Precio: $" & precios(posicion).ToString("N2") & " | Subtotal: $" & subtotales(posicion).ToString("N2") & " | Impuesto: $" & impuestos(posicion).ToString("N2") & " | Total: $" & totales(posicion).ToString("N2") & " | Estado: " & estados(posicion))
                            Else
                                Console.WriteLine("ID no encontrada.")
                            End If
                        ElseIf tipoBusqueda = 2 Then
                            Console.Write("Ingrese el nombre del cliente: ")
                            Dim clienteBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If clientes(i).ToLower().Contains(clienteBuscar.ToLower()) Then
                                    Console.WriteLine("ID: " & ids(i) & " | Cliente: " & clientes(i) & " | Servicio: " & servicios(i) & " | Descripcion: " & descripciones(i) & " | Cantidad: " & cantidades(i) & " | Precio: $" & precios(i).ToString("N2") & " | Subtotal: $" & subtotales(i).ToString("N2") & " | Impuesto: $" & impuestos(i).ToString("N2") & " | Total: $" & totales(i).ToString("N2") & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No se encontraron facturas para ese cliente.")
                            End If
                        ElseIf tipoBusqueda = 3 Then
                            Console.Write("Ingrese el nombre del servicio: ")
                            Dim servicioBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If servicios(i).ToLower().Contains(servicioBuscar.ToLower()) Then
                                    Console.WriteLine("ID: " & ids(i) & " | Cliente: " & clientes(i) & " | Servicio: " & servicios(i) & " | Descripcion: " & descripciones(i) & " | Cantidad: " & cantidades(i) & " | Precio: $" & precios(i).ToString("N2") & " | Subtotal: $" & subtotales(i).ToString("N2") & " | Impuesto: $" & impuestos(i).ToString("N2") & " | Total: $" & totales(i).ToString("N2") & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No se encontraron facturas para ese servicio.")
                            End If
                        Else
                            Console.WriteLine("Opcion no valida.")
                        End If
                    End If
                '----------------------'
                '--|eliminar_factura|--'
                '----------------------'
                Case 5
                    If cantidad = 0 Then
                        Console.WriteLine("No existen facturas registradas.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Cliente: " & clientes(i) & " | Servicio: " & servicios(i) & " | Cantidad: " & cantidades(i) & " | Total: $" & totales(i).ToString("N2") & " | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID de la factura a eliminar: ")
                        Dim idEliminar As Integer = Convert.ToInt32(Console.ReadLine())
                        If idEliminar >= 1 AndAlso idEliminar <= cantidad Then
                            Dim posicion As Integer = idEliminar - 1
                            For i As Integer = posicion To cantidad - 2
                                ids(i) = ids(i + 1)
                                clientes(i) = clientes(i + 1)
                                servicios(i) = servicios(i + 1)
                                descripciones(i) = descripciones(i + 1)
                                cantidades(i) = cantidades(i + 1)
                                precios(i) = precios(i + 1)
                                subtotales(i) = subtotales(i + 1)
                                impuestos(i) = impuestos(i + 1)
                                totales(i) = totales(i + 1)
                                estados(i) = estados(i + 1)
                            Next
                            cantidad -= 1
                            ids(cantidad) = 0
                            clientes(cantidad) = ""
                            servicios(cantidad) = ""
                            descripciones(cantidad) = ""
                            cantidades(cantidad) = 0
                            precios(cantidad) = 0
                            subtotales(cantidad) = 0
                            impuestos(cantidad) = 0
                            totales(cantidad) = 0
                            estados(cantidad) = ""
                            For i As Integer = 0 To cantidad - 1
                                ids(i) = i + 1
                            Next
                            Console.WriteLine("Factura eliminada correctamente.")
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '----------------------'
                '--|calcular_factura|--'
                '----------------------'
                Case 6
                    If cantidad = 0 Then
                        Console.WriteLine("No existen facturas registradas.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Cliente: " & clientes(i) & " | Servicio: " & servicios(i) & " | Cantidad: " & cantidades(i) & " | Precio: $" & precios(i).ToString("N2") & " | Total: $" & totales(i).ToString("N2"))
                        Next
                        Console.Write("Ingrese el ID de la factura a calcular: ")
                        Dim idCalcular As Integer = Convert.ToInt32(Console.ReadLine())
                        If idCalcular >= 1 AndAlso idCalcular <= cantidad Then
                            Dim posicion As Integer = idCalcular - 1
                            subtotales(posicion) = cantidades(posicion) * precios(posicion)
                            impuestos(posicion) = subtotales(posicion) * 0.19
                            totales(posicion) = subtotales(posicion) + impuestos(posicion)
                            Console.WriteLine("Detalle de la factura")
                            Console.WriteLine("ID: " & ids(posicion))
                            Console.WriteLine("Cliente: " & clientes(posicion))
                            Console.WriteLine("Servicio: " & servicios(posicion))
                            Console.WriteLine("Descripcion: " & descripciones(posicion))
                            Console.WriteLine("Cantidad: " & cantidades(posicion))
                            Console.WriteLine("Precio unitario: $" & precios(posicion).ToString("N2"))
                            Console.WriteLine("Subtotal: $" & subtotales(posicion).ToString("N2"))
                            Console.WriteLine("Impuesto (19%): $" & impuestos(posicion).ToString("N2"))
                            Console.WriteLine("Total: $" & totales(posicion).ToString("N2"))
                            Console.WriteLine("Estado: " & estados(posicion))
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '---------------------'
                '--|mostrar_resumen|--'
                '---------------------'
                Case 7
                    If cantidad = 0 Then
                        Console.WriteLine("No existen facturas registradas.")
                    Else
                        Dim pendientes As Integer = 0
                        Dim pagadas As Integer = 0
                        Dim canceladas As Integer = 0
                        Dim totalFacturado As Double = 0
                        For i As Integer = 0 To cantidad - 1
                            totalFacturado += totales(i)
                            If estados(i) = "Pendiente" Then
                                pendientes += 1
                            ElseIf estados(i) = "Pagada" Then
                                pagadas += 1
                            ElseIf estados(i) = "Cancelada" Then
                                canceladas += 1
                            End If
                        Next
                        Console.WriteLine("Total de facturas: " & cantidad)
                        Console.WriteLine("Facturas pendientes: " & pendientes)
                        Console.WriteLine("Facturas pagadas: " & pagadas)
                        Console.WriteLine("Facturas canceladas: " & canceladas)
                        Console.WriteLine("Total facturado: $" & totalFacturado.ToString("N2"))
                    End If
                '------------------------------'
                '--|salir_del_menu_principal|--'
                '------------------------------'
                Case 8
                    Console.WriteLine("Gracias por utilizar Facturador de Servicios.")
                Case Else
                    Console.WriteLine("Opcion no valida.")
            End Select
        Loop While opcion <> 8
    End Sub
End Module