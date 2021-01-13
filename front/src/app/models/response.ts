export class ResponseApi <T> {
    success: boolean
    data: {
        personObjects: T
    }
}