
<template>
  <div class="combobox">
    <input
      :class="['combobox-search', { 'border-red': isBorderRed }]"
      type="text"
      v-model="comboboxText"
      ref="inputCombobox"
      @blur="cbbOnBlur"
    />
    <button class="combobox-option" @click="comboboxOptionOnClick">
      <div class="combobox-icon position-icon-down-black"></div>
    </button>
    <div v-if="isShowListDepartment" class="combobox-data">
      <div class="data-header">
        <p class="Department-name">Tên đơn vị</p>
      </div>
      <div
        class="combobox-item"
        v-for="item in listItemShow"
        :key="item.DepartmentId"
        value="item.DepartmentId"
        @click="comboboxItemOnClick(item.DepartmentId)"
        :class="{ 'item-selected': item.DepartmentId == comboboxValue }"
      >
        <p class="Department-name">{{ item.DepartmentName }}</p>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "TheCombobox",
  props: {
    // có hiển thị list item hay không
    isShowData: {
      type: Boolean,
      default: false,
    },
    // ds các item để lựa chọn
    listItem: {
      default: [],
    },
    // giá trị của component này
    comboboxValue: {
      type: String,
      default: null,
    },
    // kiểm soát việc chọn lại
    reSelect: {
      type: Boolean,
      default: false,
    },
    // border của input có đỏ hay không
    isBorderRed: {
      type: Boolean,
      default: false,
    },
    //title
    inputTitle: String,
  },
  data() {
    return {
      listItemShow: [],
      comboboxText: "",
      // index của item được chon trong list. dùng khi keyup.up, keyup.down
      index: -1,
      isShowListDepartment: false,
    };
  },
  created() {
    this.listItemShow = this.listItem;
  },
  watch: {
    // khi nhận list item mới thì gán ngay cho list show để có thể show ra
    listItem() {
      this.listItemShow = this.listItem;
    },
    //khi nhận được sự thay dổi reSelect => người dùng chọn lại => thay đổi text
    reSelect() {
      this.listItem.forEach((item) => {
        if (item.DepartmentId == this.comboboxValue) {
          this.comboboxText = item.DepartmentName;
          console.log(4332533);
        }
      });
    },
  },
  methods: {
    /**
     * Xử lí tìm kiếm các item hợp lệ với searchTerms để thêm vào listShow
     * Author TrungTQ
     * */
    // searchCombobox() {
    //   var searchTerms = this.comboboxText;
    //   this.listItemShow = [];
    //   this.listItem.forEach((item) => {
    //     if (
    //       item.DepartmentCode.toLowerCase().includes(
    //         searchTerms.toLowerCase()
    //       ) ||
    //       item.DepartmentName.toLowerCase().includes(searchTerms.toLowerCase())
    //     ) {
    //       this.listItemShow.push(item);
    //     }
    //   });
    //   if (this.listItemShow.length > 0) {
    //     this.$emit("comboboxOnSelect", this.listItemShow[0].DepartmentId);
    //     this.index = 0;
    //   }
    // },
    /**
     * Sự kiện khi click vào một item trong list
     * @param id
     * Author TrungTQ
     */
    comboboxItemOnClick(id) {
      this.$emit("comboboxOnSelect", id);
    },
    /**
     * Sự kiện khi click vào btn Option
     * Author TrungTQ
     * */
    comboboxOptionOnClick() {
      this.$refs.inputCombobox.focus();
      setTimeout(() => {
        this.isShowListDepartment = true;
      }, 300);
      this.listItemShow = [];
      this.listItem.forEach((item) => {
        this.listItemShow.push(item);
      });
      for (let i = 0; i < this.listItemShow.length; i++) {
        if (this.comboboxValue == this.listItemShow[i].DepartmentId) {
          this.index = i;
        }
      }
    },
    /**
     * Sự kiện khi blur cbb
     * */
    cbbOnBlur() {
      setTimeout(() => {
        this.isShowListDepartment = false;
        this.$emit("cbbOnBlur");
      }, 200);
    },
  },
};
</script>


<style scoped>
.combobox {
  position: relative;
  float: left;
  width: 100%;
}

.combobox-search {
  outline: 0;
  border: 0;
width: 100%;
  height: 32px !important;
  border-radius: 2px;
  border: 1px solid #babec5;
  padding: 5px 42px 5px 10px;
  box-sizing: border-box;
}

.border-red {
  border-color: #ff0000 !important;
}

.combobox-search:focus {
  border-color: #2c9f1c;
}

.combobox-search:focus {
  border-color: #2ca01c;
}

.combobox-option {
  border: 0;
  outline: 0;
  width: 32px;
  height: 30px;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  position: absolute;
  top: 1px;
  right: 1px;
  z-index: 5;
}

.combobox-option:hover {
  background-color: #e0e0e0;
}

.combobox-option:focus {
  background-color: #e0e0e0;
}

.combobox-data {
  position: absolute;
  top: 35px;
  left: 0;
  width: 100%;
  height: auto;
  border: 1px solid #babec5;
  border-radius: 2px;
  box-sizing: border-box;
  z-index: 2000;
  background-color: #fff;
  box-shadow: 1px 2px 4px 1px #454545;
}

.data-header {
  height: 32px;
  width: 100%;
  background-color: #f4f5f8;
}

.Department-code {
  font-size: 13px;
  display: block;
  margin: 0;
  float: left;
  height: 100%;
  width: 100px;
  padding-left: 10px;
  line-height: 32px;
  box-sizing: border-box;
}

.Department-name {
  display: block;
  margin: 0;
  font-weight: 100;
  float: left;
  height: 100%;
  width: calc(100% - 100px);
  padding-left: 10px;
  line-height: 32px;
  font-size: 13px;
  box-sizing: border-box;
}

.data-header .Department-code {
  font-weight: 600;
}

.data-header .Department-name {
  font-weight: 600;
}

.combobox-item {
  width: 100%;
  height: 32px;
  float: left;
  cursor: pointer;
}

.combobox-item:hover {
  background-color: #ebedf0 !important;
  color: #35bf50 !important;
}

.item-selected {
  background-color: #ebedf0 !important;
  color: #35bf50 !important;
}
</style>