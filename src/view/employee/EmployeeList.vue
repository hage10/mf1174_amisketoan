<template>
  <div class="employee-content">
    <div class="employee-header">
      <div class="header-row">
        <div class="title-content">Nhân viên</div>
        <Button
          buttonText="Thêm mới nhân viên"
          buttonClass="button-primary"
          @btnClick="btnAddOnClick"
        />
      </div>
    </div>
    <div class="employee-toolbar">
      <div class="toolbar-row">
        <div class="toolbar-left"></div>
        <div class="toolbar-right">
          <div class="input-search-wrapper">
            <Input
              inputClass="input-search"
              inputType="text"
              inputPlacehoder="Tìm theo mã, tên nhân viên"
              :inputValue="searchTerms"
              v-model="searchTerms"
              @inputOnEnter="enterSearch"
            />
            <div class="icon-search"></div>
          </div>
          <div class="btn-refresh reload-icon" @click="btnRefreshOnClick"></div>
        </div>
      </div>
    </div>
    <div class="table-paging">
      <TheTable
        :tableColumns="tableColumns"
        :tableDataList="tableDataList"
        @chooseAnEmployee="chooseAnEmployee"
      ></TheTable>
      <PagingBar :totalRecord="totalRecord" />
    </div>
    <EmployeeDetail
      v-if="isShowDialog"
      @closeForm="
        () => {
          isShowDialog = false;
        }
      "
      :mode="dialogMode"
      :employeeId="myEmployeeId"
      :isReOpen="isReOpenDialog"
    />
  </div>
</template>

<script>
import Button from "../../components/base/Button.vue";
import Input from "../../components/base/Input.vue";
import TheTable from "../../components/base/Table.vue";
import PagingBar from "../../components/base/PagingBar.vue";
import EmployeeApi from "../../api/entities/EmployeeApi";

import { employeeColumns } from "./EmployeeColumns.js";
import EmployeeDetail from "./EmployeeDetail.vue";
export default {
  name: "TheEmployeeList",
  components: {
    Button,
    Input,
    TheTable,
    PagingBar,
    EmployeeDetail,
  },
  data() {
    return {
      myEmployeeId: "",
      employeeSelected: {},
      //-------------------------------
      // các mảng cột và hàng truyền vào cho table
      tableColumns: employeeColumns,
      tableDataList: [],

      // các biến liên quan đến xử lí với dialog
      isShowDialog: false,
      dialogMode: "",
      isReOpenDialog: false,

    };
  },
  methods: {
    btnAddOnClick() {
      this.isShowDialog = true;
      this.dialogMode = "add";
    },
    /**
     * Nhận sự kiện khi table chọn 1 nhân viên và truyền lên kèm theo id nhân viên => mở dilalog sửa
     * @param employeeId
     * Author HieuNV
     */
    chooseAnEmployee(employeeId) {
      this.isShowDialog = true;
      this.dialogMode = "edit";
      setTimeout(() => {
        this.isReOpenDialog = !this.isReOpenDialog;
      }, 100);
      this.myEmployeeId = employeeId;
    },
    load() {
      /**
       * Gọi api lấy dữ liệu
       * Author: TrungTQ(18/06/2022)
       */
      try {
        var me = this;
        EmployeeApi.getAll()
          .then(function (emp) {
            me.tableDataList = emp.data;
            console.log(emp);
          })
          .catch(function (emp) {
            console.log(emp);
          });
      } catch (error) {
        console.log(error);
      }
    },
  },

  created() {
    this.emitter.on("btnEditOnClick", (id) => {
      this.isShowDialog = true;
      this.dialogMode = "edit";
      this.myEmployeeId = id;
    });

    this.load();
    this.emitter.on("load", () => {
      this.load();
    });
  },
};
</script>

<style>
@import url(../../css/icon-position.css);

.employee-content {
  background-color: #f4f5f8;
  float: left;
  width: 100%;
  height: calc(100% - 48px);
  padding-left: 20px;
  padding-right: 30px;
  box-sizing: border-box;
}

.employee-content .employee-header {
  background-color: #f4f5f8;
  width: 100%;
  height: 84px;
  padding: 24px 0px 24px 0px;
  box-sizing: border-box;
  float: left;
}

.employee-content .employee-header .header-row {
  width: 100%;
  height: 36px;
  color: #111111;
  display: flex;
  align-items: center;
  justify-content: space-between;
}
.title-content {
  font-size: 24px;
}

.employee-content .employee-header .header-row {
  line-height: 36px;
  font-weight: 700;
  font-size: 24px;
}

.employee-toolbar {
  width: 100%;
  height: 68px;
  padding: 16px 20px;
  box-sizing: border-box;
  background-color: #fff;
  float: left;
}

.employee-toolbar .toolbar-row {
  width: 100%;
  height: 36px;
  display: flex;
  justify-content: space-between;
}

.toolbar-left {
  height: 100%;
  width: auto;
}

.batch-function-button {
  width: auto;
  height: 100%;
  background-color: #fff;
  border: 1px solid #8d9096;
  box-sizing: border-box;
  border-radius: 30px;
  padding: 0px 16px;
  align-items: center;
  display: flex;
  justify-content: flex-start;
  position: relative;
  cursor: pointer;
}

.btn-batch-disable {
  border: 2px solid #b1b2b3;
}

.batch-function-button p {
  font-weight: 600;
  line-height: 36px;
}

.batch-function-button .dropdown-icon {
  margin-left: 5px;
}

.batch-list {
  position: absolute;
  top: 38px;
  right: 0;
  width: 104px;
  height: auto;
  padding: 1px 2px;
  box-sizing: border-box;
  border: 1px solid #b1b2b3;
  border-radius: 3px;
  z-index: 32333;
  background-color: #fff;
}

.delete-batch {
  width: 100%;
  height: 28px;
  line-height: 28px;
  display: flex;
  align-items: center;
  padding-left: 10px;
  cursor: pointer;
  box-sizing: border-box;
}

.delete-batch:hover {
  background-color: #e8e9ec;
}

.toolbar-right {
  height: 100%;
  width: auto;
  display: flex;
  align-items: flex-end;
  justify-content: flex-end;
}

.input-search-wrapper {
  width: 240px;
  height: 32px;
  position: relative;
  margin-right: 10px;
  font-style: italic;
  font-size: 11px;
}

.input-search-wrapper .icon-search {
  position: absolute;
  top: 8px;
  right: 8px;
}

.btn-refresh {
  margin: 4px 6px;
  cursor: pointer;
}

.btn-refresh:hover {
  background-position: -1096px -88px;
}

.btn-export {
  cursor: pointer;
  margin-left: 6px;
}

.btn-export:hover {
  background-position: -705px -257px;
}

.table-paging {
  width: 100%;
  /*height: auto;*/
  height: calc(100% - 152px);
  background-color: #f4f5f8;
  /*padding-right: 20px;*/
  /*padding-left: 20px;*/
  box-sizing: border-box;
  float: left;
}
</style>