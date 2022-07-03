<template>
  <div
    :class="['list-option', { 'list-option-hide': isHide }]"
    :style="functionListPositionStr"
  >
    <div class="item-option clone-button" @click="btnCloneOnClick">
      Nhân bản
    </div>
    <div class="item-option delete-button" @click="btnDeleteOnClick">Xóa</div>
    <div class="item-option stop-button">Ngừng sử dụng</div>
  </div>
</template>

<script>

import EmployeeApi from "../../api/entities/EmployeeApi";

export default {
  name: "FunctionToolList",
  data() {
    return {
      isHide: true,
      // style position của components này
      functionListPositionStr: "",
      myEmployeeId: "",
      myEmployeeCode: "",
    };
  },
  methods: {
    // /**
    //  * Sự kiện khi click nhân bản
    //  * Author TrungTQ
    //  * */
    btnCloneOnClick() {
        // this.isHide = true;
        this.emitter.emit('cloneEmployee',this.myEmployeeId);
    },
    // /**
    //  * Sự kiện khi click Xóa
    //  * Author TrungTQ
    //  * */
    btnDeleteOnClick() {
      this.isHide = true;
      this.emitter.emit(
        "showPopup",
        `Bạn có thực sự muốn xóa nhân viên <${this.myEmployeeCode}> không?###warning###xw###delete`
      );
    },
  },
  created() {
    //sự kiện lắng nghe mở function list
    this.emitter.on("showFunctionList", (a) => {
      this.functionListPositionStr = a.split("###")[0];
      this.myEmployeeId = a.split("###")[1];
      this.myEmployeeCode = a.split("###")[2];
      this.isHide = false;
    });
    //sự kiện lắng nghe ẩn function list
    this.emitter.on("hideFunctionList", () => {
      this.isHide = true;
    });
    //sự kiện lắng nghe xác nhận xóa nhân viên
    this.emitter.on("confirmToDelete", () => {
      EmployeeApi.delete(this.myEmployeeId)
        .then((res) => {
          console.log(res);
          this.emitter.emit("showMes", "Xóa thành công!###success");
          this.emitter.emit("load");
        })
        .catch((err) => {
          console.log(err);
          this.emitter.emit("showMes", "Xóa thất bại!###danger");
        });
    });

  },
};
</script>

<style scoped>
.list-option {
  width: 118px;
  height: auto;
  padding: 2px 1px;
  box-sizing: border-box;
  position: fixed;
  background-color: #fff;
  border: 1px solid #babec5;
  border-radius: 2px;
  z-index: 15000;
}

.list-option-hide {
  display: none;
}

.item-option {
  width: 100%;
  height: 28px;
  float: left;
  font-size: 13px;
  line-height: 28px;
  padding-left: 10px;
  box-sizing: border-box;
  cursor: pointer;
}

.item-option:hover {
  background-color: #e8e9ec;
  color: #08bf1e;
}
</style>