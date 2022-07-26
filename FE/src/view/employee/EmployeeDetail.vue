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
                  v-model="employeeModel.employeeCode"
                  @focus="
                    () => {
                      touched.employeeCode = true;
                    }
                  "
                  :class="{
                    'border-red':
                      v$.employeeModel.employeeCode.$invalid &&
                      touched.employeeCode,
                  }"
                />
              </div>
              <div class="prop-item">
                <p>Tên <font color="red">*</font></p>
                <input
                  type="text"
                  class="m-input input-w-4"
                  v-model="employeeModel.fullName"
                  @focus="
                    () => {
                      touched.employeeName = true;
                    }
                  "
                  :class="{
                    'border-red':
                      v$.employeeModel.fullName.$invalid &&
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
                  v-model="employeeModel.dateOfBirth"
                />
              </div>
              <div class="prop-item">
                <div class="input-title">
                  <div>Giới tính</div>
                </div>
                <div class="gender">
                  <div
                    class="check-sex"
                    v-for="option in genderOptions"
                    :key="option.id"
                  >
                    <label class="m-component-radio">
                      <input
                        class="male radio-input"
                        name="gender"
                        type="radio"
                        :value="option.id"
                        v-model="employeeModel.gender"
                      />
                      <span class="m-radiocheck">
                        <span class="image-radio"></span>
                      </span>
                      <span class="role">{{ option.name }}</span>
                    </label>
                  </div>
                </div>
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
                      if (!employeeModel.departmentId)
                        touched.departmentId = true;
                    }
                  "
                  @comboboxOnSelect="comboboxOnSelect"
                  :comboboxValue="employeeModel.departmentId"
                  :isBorderRed="
                    v$.employeeModel.departmentId.$invalid &&
                    touched.departmentId
                  "
                  :reSelect="reSelectCbb"
                  v-model="employeeModel.departmentName"
                />
              </div>
            </div>
            <div class="hatf-row-dialog">
              <div class="prop-item">
                <p>Số CMND</p>
                <input
                  type="text"
                  class="m-input input-w-4"
                  v-model="employeeModel.identityNumber"
                />
              </div>
              <div class="prop-item">
                <p>Ngày cấp</p>
                <input
                  type="date"
                  class="m-input input-w-2"
                  v-model="employeeModel.identityDate"
                  :inputValue="formatDateToValue(employeeModel.identityPlace)"
                />
              </div>
            </div>
          </div>
          <div class="dialog-row">
            <div class="hatf-row-dialog">
              <div class="prop-item">
                <p>Chức danh</p>
                <input
                  type="text"
                  class="m-input input-w-6"
                  v-model="employeeModel.employeePosition"
                />
              </div>
            </div>
            <div class="hatf-row-dialog">
              <div class="prop-item">
                <p>Nơi cấp</p>
                <input
                  type="text"
                  class="m-input input-w-6"
                  v-model="employeeModel.identityPlace"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="dialog-down">
          <div class="dialog-row">
            <div class="prop-item">
              <p>Địa chỉ</p>
              <input
                type="text"
                class="m-input input-w-12"
                v-model="employeeModel.address"
              />
            </div>
          </div>
          <div class="dialog-row-lite">
            <div class="prop-item w-205">
              <p>Điện thoại di động</p>
              <input
                type="text"
                class="m-input input-w-3"
                v-model="employeeModel.phoneNumber"
              />
            </div>
            <div class="prop-item w-205">
              <p>Điện thoại cố định</p>
              <input
                type="text"
                class="m-input input-w-3"
                v-model="employeeModel.telephoneNumber"
              />
            </div>
            <div class="prop-item w-205">
              <p>Email</p>
              <input
                type="text w-205"
                class="m-input input-w-3"
                v-model="employeeModel.email"
              />
            </div>
          </div>
          <div class="dialog-row-lite">
            <div class="prop-item w-205">
              <p>Tài khoản ngân hàng</p>
              <input
                type="text"
                class="m-input input-w-3"
                v-model="employeeModel.bankAccountNumber"
              />
            </div>
            <div class="prop-item w-205">
              <p>Tên ngân hàng</p>
              <input
                type="text"
                class="m-input input-w-3"
                v-model="employeeModel.bankName"
              />
            </div>
            <div class="prop-item w-205">
              <p>Chi nhánh</p>
              <input
                type="text"
                class="m-input input-w-3"
                v-model="employeeModel.bankBranchName"
              />
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
            buttonText="Cất và Thêm"
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
import EmployeeApi from "@/api/entities/EmployeeApi.js";
import DepartmentApi from "@/api/entities/DepartmentApi.js";
import { required, helpers } from "@vuelidate/validators";
import useVuelidate from "@vuelidate/core";
import { EmployeeModel } from "@/models/EmployeeModels";
import FormatData from "../../utils/Format.js";

export default {
  name: "EmployeeDialog",
  components: {
    Checkbox,
    Button,
    Combobox,
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
    isReOpen: {
      type: Boolean,
      default: false,
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
      // object: employee model để truyền và nhận dữ liệu từ các input
      employeeModel: {},
      // biến truyền vào thông báo combobox thay đổi lựa chọn
      reSelectCbb: false,
      // các option của giới tính
      genderOptions: [
        {
          id: 1,
          name: "Nam",
        },
        {
          id: 0,
          name: "Nữ",
        },
        {
          id: 2,
          name: "Khác",
        },
      ],
      originalModel: {},
    };
  },
  /**
   * Validate dữ liệu 3 trường mã nhân viên, tên nhân viên, đơn vị
   * Author Trung TQ
   */
  validations() {
    return {
      employeeModel: {
        employeeCode: {
          required: helpers.withMessage(
            "Mã nhân viên không được để trống",
            required
          ),
        },
        fullName: {
          required: helpers.withMessage(
            "Tên nhân viên không được để trống",
            required
          ),
        },
        departmentId: {
          required: helpers.withMessage("Đơn vị không được để trống", required),
        },
      },
    };
  },
  methods: {
    /**
     * formatDate
     * @param _date
     * Author TrungTQ
     */
    formatDateToValue(_date) {
      return FormatData.formatDateToValue(_date);
    },
    /**
     * đóng form chi tiết
     * Author TrungTQ
     */
    hideDialog() {
      this.$emit("closeForm");
    },

    /**
     * validate từ BE
     * Author: TrungTQ
     * @param {*} err
     */
    errorMsg(err) {
      let data = err.response.data;
      console.log(data);
      if (
        !data.code &&
        data.errors.EmployeeCode[0].includes("Mã nhân viên không hợp lệ")
      ) {
        this.emitter.emit(
          "showPopup",
          `Mã nhân viên không hợp lệ.###warning###u###messenger`
        );
      } else if (
        data.code &&
        err.response.data.data.msg.includes(
          "An error occurred while updating the entries. See the inner exception for details."
        )
      ) {
        this.emitter.emit(
          "showPopup",
          `Mã nhân viên <${this.employeeModel.employeeCode}> đã tồn tại trong hệ thống, vui lòng kiểm tra lại.###warning###u###messenger`
        );
      }
    },
    /**
     * Xóa dữ liệu trong form chi tiết khi ấn nút cất và thêm
     * Author: TrungTQ
     */
    async clearForm() {
      let newEmployeeCode;
      await EmployeeApi.getNewCode()
        .then((res) => {
          newEmployeeCode = res.data.data;
        })
        .catch((err) => {
          console.log(err);
        });
      this.employeeModel = Object.assign({}, EmployeeModel);
      this.employeeModel.employeeCode = newEmployeeCode;
      this.employeeModel.gender = 1;
      this.touched = {
        employeeCode: false,
        employeeName: false,
        departmentId: false,
      };
      this.reSelectCbb = !this.reSelectCbb;
      this.$refs.txtEmployeeCodeRef.focus();
    },
    async save(modeButton) {
      //bắt đầu thực hiện check validate
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
          this.v$.$silentErrors[0].$message + "###warning###t###messenger"
        );
      } else {
        //mode thêm
        if (this.mode == "add") {
          EmployeeApi.add(this.employeeModel)
            .then(async (res) => {
              console.log(res);
              this.emitter.emit("showMes", "Thêm mới thành công!###success");
              this.emitter.emit("load");
              if (modeButton == "save") {
                this.$emit("closeForm");
              } else if (modeButton == "saveandadd") {
                this.clearForm();
              }
            })
            .catch((err) => {
              this.errorMsg(err);
            });
          //mode sửa
        } else if (this.mode == "edit") {
          console.log(this.employeeModel);
          EmployeeApi.update(this.employeeId, this.employeeModel)
            .then(async (res) => {
              console.log(res);
              this.emitter.emit("showMes", "Cập nhật thành công!###success");
              this.emitter.emit("load");
              if (modeButton == "save") {
                this.$emit("closeForm");
              } else if (modeButton == "saveandadd") {
                this.clearForm();
              }
            })
            .catch((err) => {
              this.errorMsg(err);
            });
        } else {
          EmployeeApi.add(this.employeeModel)
            .then(async (res) => {
              console.log(res);
              this.emitter.emit("showMes", "Nhân bản thành công!###success");
              this.emitter.emit("load");
              if (modeButton == "save") {
                this.$emit("closeForm");
              } else if (modeButton == "saveandadd") {
                this.clearForm();
              }
            })
            .catch((err) => {
              this.errorMsg(err);
            });
        }
      }
    },

    /**
     * Ấn icon X trong form thêm mới nhân viên
     * author: TrungTQ (20/06/2022)
     */
    btnXOnClick() {
      //nếu là nhân bản và thêm mới nhân viên bấm X sẽ đóng form chi tiết
      if (this.mode == "add" || this.mode == "clone") {
        this.$emit("closeForm");
      }
      // nếu là sửa thì bấm X sẽ check dữ liệu đã bị thay đổi hay chưa
      // nếu chưa thay đổi thì đóng form chi tiết
      else if (
        JSON.stringify(this.originalModel) ===
        JSON.stringify(this.employeeModel)
      ) {
        this.$emit("closeForm");
      }
      //nếu thay đổi rồi thì hiện popup confirm
      else {
        this.emitter.emit(
          "showPopup",
          "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?###question###zxy###saveChange"
        );
      }
    },
    /**
     * Ấn button cất trong form thêm mới nhân viên
     * author: TrungTQ (20/06/2022)
     */
    btnSaveOnClick() {
      this.save("save");
    },

    /**
     * Ấn button cất và thêm trong form thêm mới nhân viên
     * author: TrungTQ (20/06/2022)
     */
    async btnSaveAndAddOnClick() {
      this.save("saveandadd");
    },
    // các hàm sử sụng cho combobox
    comboboxOnSelect(cbbValue) {
      this.employeeModel.departmentId = cbbValue;
      this.isShowDataCombobox = true;
      this.reSelectCbb = !this.reSelectCbb;
      this.v$.employee.departmentId.$touch();
      setTimeout(() => {
        this.touched.departmentId = false;
      }, 210);
    },
  },

  async created() {
    // Lắng nghe sự kiện bấm button X trong form ở mode Edit
    this.emitter.on("confirmToSaveChange", async () => {
      //bắt đầu thực hiện check validate
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
          this.v$.$silentErrors[0].$message + "###warning###t###messenger"
        );
      } else {
        EmployeeApi.update(this.employeeId, this.employeeModel)
          .then((res) => {
            console.log(res);
            this.emitter.emit("showMes", "Cập nhật thành công!###success");

            this.$emit("closeForm");
            this.emitter.emit("load");
          })
          .catch((err) => {
            this.errorMsg(err);
          });
      }
    });
    // lấy danh sách phòng ban và gán cho data listDepartment
    await DepartmentApi.getAll().then((res) => {
      console.log(res.data.data);
      this.listDepartment = res.data.data;
    });

    console.log(this.mode);

    /**
     * đầu vào là mode add thì lấy mã mới và focus vào mã nhân viên
     * Author: TrungTQ
     */
    if (this.mode == "add") {
      EmployeeApi.getNewCode()
        .then((res) => {
          let newEmployeeCode = res.data.data;
          this.employeeModel.employeeCode = newEmployeeCode;
          this.$refs.txtEmployeeCodeRef.focus();
          this.employeeModel.gender = 1;
        })
        .catch((err) => {
          console.log(err);
        });
    } else if (this.mode == "edit") {
      /**
       * đầu vào là mode edit thì gọi api lấy mã nhân viên theo Id
       * Author: TrungTQ
       */
      console.log("lấy nhân viên có id ", this.employeeId);
      EmployeeApi.getById(this.employeeId).then((res) => {
        console.log(res);
        this.employeeModel = res.data.data;
        this.reSelectCbb = !this.reSelectCbb;
        this.employeeModel.dateOfBirth = this.formatDateToValue(
          new Date(this.employeeModel.dateOfBirth)
        );
        this.employeeModel.identityDate = this.formatDateToValue(
          new Date(this.employeeModel.identityDate)
        );
        this.originalModel = Object.assign({}, this.employeeModel);
        this.$refs.txtEmployeeCodeRef.focus();
      });
    } else if (this.mode == "clone") {
      /**
       * đầu vào là mode clone thì lấy mã mới và focus vào mã nhân viên và gọi api lấy mã nhân viên theo Id
       * Author: TrungTQ
       */

      EmployeeApi.getById(this.employeeId).then(async (res) => {
        this.employeeModel = res.data.data;
        await EmployeeApi.getNewCode()
          .then((res) => {
            let newEmployeeCode = res.data.data;
            this.employeeModel.employeeCode = newEmployeeCode;
            this.$refs.txtEmployeeCodeRef.focus();
          })
          .catch((err) => {
            console.log(err);
          });

        this.reSelectCbb = !this.reSelectCbb;
        this.employeeModel.dateOfBirth = this.formatDateToValue(
          new Date(this.employeeModel.dateOfBirth)
        );
        this.employeeModel.identityDate = this.formatDateToValue(
          new Date(this.employeeModel.identityDate)
        );
        this.originalModel = Object.assign({}, this.employeeModel);
      });
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

.m-component-radio {
  display: flex;
  position: relative;
  align-items: center;
  cursor: pointer;
  padding-right: 20px;
}

.radio-input {
  position: absolute;
  opacity: 0;
}

.radio-input:checked {
  display: none;
}

.radio-input:checked + .m-radiocheck {
  border: 1px solid #2ca01c;
}

.radio-input:checked + .m-radiocheck > .image-radio {
  display: block;
}

.image-radio {
  display: none;
  position: absolute;
  background-color: #2ca01c;
  width: 10px;
  height: 10px;
  border-radius: 50%;
}

.m-radiocheck {
  display: flex;
  border: 1px solid #afafaf;
  width: 18px;
  height: 18px;
  justify-content: center;
  align-items: center;
  border-radius: 50%;
  top: 0;
  left: 0;
  transition: all 0.2s ease;
  background: #fff;
}

.role {
  padding-left: 10px;
}
.gender {
  display: flex;

  margin-top: 7px;
}
</style>