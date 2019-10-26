export class ResponseModel<T> {
    succeed: boolean;
    message: string;
    data: T;
    errors: string[];
}