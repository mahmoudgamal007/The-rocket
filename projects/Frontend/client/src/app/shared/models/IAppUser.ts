import { IAddress } from "./IAddress";
import { IAdmin } from "./admin";
import { IBuyer } from "./Ibuyer";
import { ILocation } from "./location";
import { IPhone } from "./Iphone";
import { ISeller } from "./Iseller";

export interface IAppUser {
    id?: string;
    userName?: string;
    email?: string;
    password?: string;
    confirmPassword?: string;
    seller?: ISeller;
    buyer?: IBuyer;
    admin?: IAdmin;
    phoneNumbers?: IPhone[];
    addresses?: IAddress[];
    locations?: ILocation[];
    accountType?: number;
}