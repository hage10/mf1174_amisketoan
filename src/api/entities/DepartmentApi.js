import BaseApi from "../base/BaseApi.js"

class UnitApi extends BaseApi {
    constructor() {
        super();
        this.apiController = "api/Department";
    }
}

export default new UnitApi();