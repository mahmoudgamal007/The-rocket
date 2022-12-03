export interface IOrder {
    id: number,
    deliveryStatus: number,
    isReturned: boolean,
    returnDate?: Date,
    deliveryDate?: Date,
    quantity: number,
    returnRequest?: number,
    productName: string,
    productPrice: number,
    productId: number,
    buyerId: number,
    sellerId: number
}