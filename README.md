# tl2-tp1-2023-maurijs
Pedido y cliente --> composicion
Pedido y cadete  --> agregacion

cadeteria  --- Metodo CrearPedido --- recibe los datos del pedido mas los datos del cadete y el cliente(lo obtiene de CargarPedido del cliente)
Cadeteria  --- Metodo ReasignarPedido ---
Cadeteria  --- Metodo EliminarPedido ---
Cadeteria  --- Metodo GenerarInformes ---
Cadeteria  --- Metodo CambiarEstadoDelPedido ---


Cadete ---  Metodo CargarPedido ---
Cadete ---  cantidad Pedidos Entregados ---

Pedidos --- Cambiar estado ---

Los atributos deben ser tratados privados siempre, salvo en excepciones tecnologica, como por ejemplo a veces se necesita que el atributo sea publica para poder serializar
