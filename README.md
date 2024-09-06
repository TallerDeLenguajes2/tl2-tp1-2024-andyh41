# Sistema para una Cadetería

Este proyecto implementa un sistema para una empresa de cadetería con el objetivo de asignar pedidos a los cadetes, hacer un seguimiento de los pedidos despachados y calcular el jornal correspondiente para cada cadete. El sistema también permite generar informes de actividad de la cadetería.

## Preguntas y Respuestas

### 1. ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?

- **Composición:** La relación entre **Cadetería** y **Cadete** es de composición, ya que los cadetes solo existen en el contexto de la cadetería. Si se elimina la cadetería, los cadetes también deberían eliminarse.

- **Agregación:** La relación entre **Cadete** y **Pedidos** es de agregación. Los pedidos pueden existir independientemente de un cadete en particular, lo que significa que pueden reasignarse a otro cadete sin que se destruya el pedido.

### 2. ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?

#### Cadetería

- `AgregarCadete(Cadete cadete)`: Añadir un nuevo cadete a la lista.
- `RemoverCadete(Cadete cadete)`: Eliminar un cadete de la lista.
- `ListarCadetes()`: Obtener un listado de todos los cadetes.

#### Cadete

- `AgregarPedido(Pedido pedido)`: Añadir un pedido al listado de pedidos del cadete.
- `EliminarPedido(Pedido pedido)`: Eliminar un pedido del listado de pedidos.
- `JornalACobrar()`: Calcular y ver el jornal a cobrar en base a los pedidos asignados.
- `ListarPedidos()`: Obtener un listado de todos los pedidos asignados.

### 3. Teniendo en cuenta los principios de abstracción y ocultamiento, ¿qué atributos, propiedades y métodos deberían ser públicos y cuáles privados?

#### Atributos y Propiedades

- **Privados (`private`):**
  - Atributos que representan datos internos y no deben ser modificados directamente por otras clases.
  - Ejemplos: `Direccion`, `Telefono` en `Cadete`; `ListadoPedidos` en `Cadete`, `ListadoCadetes` en `Cadetería`.

- **Públicos (`public`):**
  - Métodos de acceso y manipulación que deben estar disponibles para otras clases.
  - Ejemplos: `ListarCadetes()`, `AgregarPedido()`, `JornalACobra()`.

#### Métodos

- **Privados (`private`):** Métodos que implementan detalles específicos de la funcionalidad interna y no deben ser accesibles desde fuera de la clase (e.g., `calcularDistancia()` si es un cálculo interno).

- **Públicos (`public`):** Métodos que definen la interfaz pública de la clase y deben estar accesibles para otras clases, como `AgregarPedido()` y `VerDatosCliente()`.

### 4. ¿Cómo diseñaría los constructores de cada una de las clases?


public Pedidos(string nombre, string direccion, string telefono, string refDeDireccion, string obs){

    Nro = nextNumeroPedido++;
    Obs = obs;
    EstadoPedido = Estado.Aceptado;

    this.cliente = new Cliente(){
        Nombre = nombre,
        Direccion = direccion,
        Telefono = telefono,
        RefDeDireccion = refDeDireccion
        };
}


public Cadete(string nombre, string direccion, string telefono){

    Id = nextId++; 
    Nombre = nombre;
    Direccion = direccion;
    Telefono = telefono;
    Id = id;
         
}


public Cadeteria(string nombre, string telefono){

    Nombre = nombre;
    Telefono = telefono;
           
}

