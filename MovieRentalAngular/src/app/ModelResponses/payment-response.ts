import { RentResponse } from "./rent-response";

export interface PaymentResponse{
    $id : string;
    id_Payment : number;
    price : number;
    rent : RentResponse;
}