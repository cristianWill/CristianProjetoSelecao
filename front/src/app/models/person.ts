import { newArray } from "@angular/compiler/src/util";
import { ModelBase } from "./modelBase";
import { Phone } from "./phone";

export class Person extends ModelBase{
    name: string
    phones: Phone[]

    constructor(p?: Person)
    {
        super(p)

        this.phones = []

        if(!p)
            return
            
        this.name = p.name
        this.phones = p.phones.map(x => new Phone(x))
    }
}