<template>
  <div class="dialog">
    <div class="dialog-modal"></div>
    <div class="dialog-content">
      <div class="dialog-header">
        <p class="dialog-title">Thông tin nhân viên</p>
        <Checkbox />
        <p class="choose-user">Là khách hàng</p>
        <Checkbox />
        <p class="choose-user">Là nhà cung cấp</p>
        <div class="help-btn help-icon"></div>
        <div class="x-btn close-icon" @click="btnXOnClick"></div>
      </div>
      <div class="dialog-body">
        <div class="dialog-up">
          <div class="dialog-row">
            <div class="hatf-row-dialog">
              <div class="prop-item">
                <p>Mã <font color="red">*</font></p>
                <input
                  type="text"
                  class="m-input input-w-2"
                  ref="txtEmployeeCodeRef"
                  v-model="employeeModel.EmployeeCode"
                  :inputValue="employeeModel.EmployeeCode"
                  @focus="
                    () => {
                      touched.employeeCode = true;
                    }
                  "
                  :class="{
                    'border-red':
                      v$.employeeModel.EmployeeCode.$invalid &&
                      touched.employeeCode,
                  }"
                />
              </div>
              <div class="prop-item">
                <p>Tên <font color="red">*</font></p>
                <input
                  type="text"
                  class="m-input input-w-4"
                  v-model="employeeModel.EmployeeName"
                  @focus="
                    () => {
                      touched.employeeName = true;
                    }
                  "
                  :class="{
                    'border-red':
                      v$.employeeModel.EmployeeName.$invalid &&
                      touched.employeeName,
                  }"
                />
              </div>
            </div>
            <div class="hatf-row-dialog">
              <div class="prop-item">
                <p>Ngày sinh</p>
                <input
                  type="date"
                  class="m-input input-w-2"
                  v-model="employeeModel.DateOfBirth"
                />
              </div>
              <div class="prop-item">
                <p>Giới tính</p>

                <RadioButtonGroup />
              </div>
            </div>
          </div>
          <div class="dialog-row">
            <div class="hatf-row-dialog">
              <div class="prop-item">
                <p>Đơn vị <font color="red">*</font></p>
                <Combobox
                  :listItem="listDepartment"
                  @cbbOnBlur="
                    () => {
                      if (!employeeModel.DepartmentId)
                        touched.departmentId = true;
                    }
                  "
                  @comboboxOnSelect="comboboxOnSelect"
                  :comboboxValue="employeeModel.DepartmentId"
                  :isBorderRed="
                    v$.employeeModel.DepartmentId.$invalid &&
                    touched.departmentId
                  "
                  :reSelect="reSelectCbb"
                />
              </div>
            </div>
            <div class="hatf-row-dialog">
              <div class="prop-item">
                <p>Số CMND</p>
                <input type="text" class="m-input input-w-4" />
              </div>
              <div class="prop-item">
                <p>Ngày cấp</p>
                <input type="date" class="m-input input-w-2" />
              </div>
            </div>
          </div>
          <div class="dialog-row">
            <div class="hatf-row-dialog">
              <div class="prop-item">
                <p>Chức danh</p>
                <input type="text" class="m-input input-w-6" />
              </div>
            </div>
            <div class="hatf-row-dialog">
              <div class="prop-item">
                <p>Nơi cấp</p>
                <input type="text" class="m-input input-w-6" />
              </div>
            </div>
          </div>
        </div>
        <div class="dialog-down">
          <div class="dialog-row">
            <div class="prop-item">
              <p>Địa chỉ</p>
              <input type="text" class="m-input input-w-12" />
            </div>
          </div>
          <div class="dialog-row-lite">
            <div class="prop-item w-205">
              <p>Điện thoại di động</p>
              <input type="text" class="m-input input-w-3" />
            </div>
            <div class="prop-item w-205">
              <p>Điện thoại cố định</p>
              <input type="text" class="m-input input-w-3" />
            </div>
            <div class="prop-item w-205">
              <p>Email</p>
              <input type="text w-205" class="m-input input-w-3" />
            </div>
          </div>
          <div class="dialog-row-lite">
            <div class="prop-item w-205">
              <p>Tài khoản ngân hàng</p>
              <input type="text" class="m-input input-w-3" />
            </div>
            <div class="prop-item w-205">
              <p>Tên ngân hàng</p>
              <input type="text" class="m-input input-w-3" />
            </div>
            <div class="prop-item w-205">
              <p>Chi nhánh</p>
              <input type="text" class="m-input input-w-3" />
            </div>
          </div>
        </div>
      </div>
      <div class="dialog-footer">
        <Button
          buttonText="Hủy"
          buttonClass="button-secondary"
          @btnClick="hideDialog"
        />
        <div class="btns-wrapper">
          <Button
            buttonText="Cất"
            buttonClass="button-secondary"
            @btnClick="btnSaveOnClick"
          />
          <Button
            buttonText="Cất và thêm"
            buttonClass="button-primary"
            @btnClick="btnSaveAndAddOnClick"
          />
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import Checkbox from "../../components/base/Checkbox.vue";
import Button from "../../components/base/Button.vue";
import Combobox from "../../components/base/Combobox.vue";
import RadioButtonGroup from "../../components/base/RadioButtonGroup.vue";
import EmployeeApi from "@/api/entities/EmployeeApi.js";
import DepartmentApi from "@/api/entities/DepartmentApi.js";
import { required, helpers } from "@vuelidate/validators";
import useVuelidate from "@vuelidate/core";

export default {
  name: "EmployeeDialog",
  components: {
    Checkbox,
    Button,
    Combobox,
    RadioButtonGroup,
  },
  setup() {
    return { v$: useVuelidate() };
  },
  props: {
    isShowDialog: {
      type: Boolean,
      default: false,
    },
    mode: {
      type: String,
      default: "add",
    },
    employeeId: {
      type: String,
      default: "",
    },
    employeeSelected: {
      type: Object,
    },
  },
  data() {
    return {
      // giá trị cho biết các trường đã focus vào lần nào hay chưa
      touched: {
        employeeCode: false,
        employeeName: false,
        departmentId: false,
      },
      // object: employee model để truyền và nhana dữ liệu từ các input
      employeeModel: {},
      // biến truyền vào thông báo combobox thay đổi lựa chọn
      reSelectCbb: false,
    };
  },
  /**
   * Validate dữ liệu 3 trường mã nhân viên, tên nhân viên, đơn vị
   * Author Trung TQ
   */
  validations() {
    return {
      employeeModel: {
        EmployeeCode: {
          required: helpers.withMessage(
            "Mã nhân viên không được để trống",
            required
          ),
        },
        EmployeeName: {
          required: helpers.withMessage(
            "Tên nhân viên không được để trống",
            required
          ),
        },
        DepartmentId: {
          required: helpers.withMessage("Đơn vị không được để trống", required),
        },
      },
    };
  },
  methods: {
    btnXOnClick() {
      this.$emit("closeForm");
    },
    async save() {
      //bắt đầu thực hiện check validate trước khi hiện cất và thêm
      this.touched = {
        employeeCode: true,
        employeeName: true,
        departmentId: true,
      };
      const result = await this.v$.$validate();
      if (!result) {
        //sự kiện gửi thông tin thông tin lỗi cho popup
        this.emitter.emit(
          "showPopup",
          this.v$.$silentErrors[0].$message + "###warning###t"
        );
      } else {
        //thực hiện post dữ liệu khi các trường đã được nhập đủ
        console.log(this.employee);
        EmployeeApi.add(this.employeeModel)
          .then((res) => {
            console.log(res);
            this.emitter.emit("showMes", "Thêm mới thành công!###success");
          })
          .catch((err) => {
            if (
              err.response.data.devMsg.includes(
                "Mã khách hàng đã tồn tại trong hệ thống"
              )
            ) {
              this.emitter.emit(
                "showPopup",
                `Mã nhân viên <${this.employeeModel.EmployeeCode}> đã tồn tại trong hệ thống, vui lòng kiểm tra lại.###warning###u`
              );
            }
          });
      }
    },
    btnSaveOnClick() {
      this.save("save");
    },

    /**
     * Ấn button cất và thêm trong form thêm mới nhân viên
     * author: TrungTQ (20/06/2022)
     */
    async btnSaveAndAddOnClick() {},
    // các hàm sử sụng cho combobox
    comboboxOnSelect(cbbValue) {
      this.employeeModel.DepartmentId = cbbValue;
      this.isShowDataCombobox = true;
      this.reSelectCbb = !this.reSelectCbb;
      this.v$.employee.DepartmentId.$touch();
      setTimeout(() => {
        this.touched.departmentId = false;
      }, 210);
    },
  },

  async created() {
    // lấy danh sách phòng ban và gán cho data listDepartment
    await DepartmentApi.getAll().then((res) => {
      console.log(res.data);
      this.listDepartment = res.data;
    });

    console.log(this.mode);
    if (this.mode == "add") {
      EmployeeApi.getNewCode()
        .then((res) => {
          let newEmployeeCode = res.data;
          this.employeeModel.EmployeeCode = newEmployeeCode;
          this.$refs.txtEmployeeCodeRef.focus();
        })
        .catch((err) => {
          console.log(err);
        });
    } else if (this.mode == "edit") {
      console.log("lấy nhân viên có id ", this.employeeId);
    }
  },
};
</script>


<style>
/* .dialog {
} */
@import url(../../css/input.css);
.dialog .dialog-modal {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #000;
  opacity: 0.4;
  z-index: 17999;
}

.dialog .dialog-content {
  z-index: 18000;
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 900px;
  height: 600px;
  background-color: #fff;
  border-radius: 3px;
  overflow: hidden;
}

.dialog-header {
  width: 100%;
  height: 73px;
  position: relative;
  display: flex;
  justify-content: flex-start;
  align-items: center;
  padding-left: 32px;
  background-color: #fff;
  box-sizing: border-box;
}

.dialog-title {
  font-size: 24px;
  font-weight: 700;
  line-height: 73px;
  margin-right: 20px;
}

.choose-user {
  margin-left: 10px;
  margin-right: 40px;
}

.x-btn {
  position: absolute;
  top: 12px;
  right: 12px;
  cursor: pointer;
}

.help-btn {
  position: absolute;
  top: 12px;
  right: 41px;
  cursor: pointer;
}

.dialog-body {
  margin-left: 32px;
  width: calc(100% - 64px);
  height: calc(100% - 148px);
  box-sizing: border-box;
}

.dialog-up {
  height: 220px;
  width: 100%;
  float: left;
}

.dialog-down {
  width: 100%;
  height: calc(100% - 250px);
  float: left;
}

.dialog-row {
  width: 100%;
  height: 65px;
  display: flex;
  justify-content: space-between;
}

.dialog-row-lite {
  width: 609px;
  height: 65px;
  display: flex;
  justify-content: space-between;
}

.hatf-row-dialog {
  width: 405px;
  height: 100%;
  display: flex;
  justify-content: space-between;
}

.prop-item {
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}

.prop-item p {
  padding: 0;
  margin: 0;
  font-size: 12px;
  font-weight: 700;
  padding-bottom: 5px;
}

.dialog-footer {
  width: calc(100% - 64px);
  margin-left: 32px;
  height: 75px;
  box-sizing: border-box;
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-top: 1px solid #e0e0e0;
}

.btns-wrapper {
  height: auto;
  width: auto;
  display: flex;
}

.btns-wrapper button:first-child {
  margin-right: 10px;
}
.border-red {
  border: 1px solid red;
}
.w-205 {
  width: 205px;
  padding-right: 6px;
}
</style>