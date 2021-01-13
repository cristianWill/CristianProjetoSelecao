import { ModelBase } from "./modelBase";
import { PhoneNumberType } from "./phoneNumberType";

export class Phone extends ModelBase{
    phoneNumber: string
    phoneNumberType: PhoneNumberType

    constructor(p?: Phone)
    {
        super()

        if(!p)
            return;

        this.phoneNumber = p.phoneNumber
        this.phoneNumberType = p.phoneNumberType
    }
}