import { ModelBase } from "./modelBase";

export class PhoneNumberType extends ModelBase{
    name: string

    constructor(p?: PhoneNumberType)
    {
        super()
        
        if(!p)
            return

        this.name = p.name
    }
}