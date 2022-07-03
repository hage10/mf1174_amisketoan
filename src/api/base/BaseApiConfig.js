import axios from "axios";

var BaseAPIConfig = axios.create({
    baseURL: "https://amis.manhnv.net/",

});

export default BaseAPIConfig;