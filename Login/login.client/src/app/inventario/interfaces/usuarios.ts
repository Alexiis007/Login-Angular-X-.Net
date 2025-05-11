export interface Usuarios {
    id: number
    nombre: string
    apellido: string
    correo: string
    contraseñaHash: string
    rol: string
    fechaRegistro: string
    activo: boolean
}
