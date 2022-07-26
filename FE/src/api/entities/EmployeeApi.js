import BaseApi from "../base/BaseApi.js"

class EmployeeApi extends BaseApi {
    constructor() {
        super();
        this.apiController = "api/Employee";
    }
}

export default new EmployeeApi();