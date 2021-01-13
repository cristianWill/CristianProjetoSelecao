export class ModelBase {
    businessEntityID: number

    constructor(model?: ModelBase){
        this.businessEntityID = model?.businessEntityID || 0
    }
}