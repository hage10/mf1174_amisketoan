<template>
  <TheContainer />
  <Popup
    :popupListButton="listButton"
    :popupType="popupType"
    :popupText="popupText"
    v-if="isShowPopup"
    @popupOnConfirm="popupOnConfirm"
  />
  <ToatmMessenger
    :mesType="mesType"
    :mesText="mesText"
    :isShowMes="isShowMes"
    @hideMes="hideMes"
  />
  <Loader :isShowLoader="isShowLoader" />
</template>

<script>
import TheContainer from "./components/layout/TheContainer.vue";
import Popup from "./components/base/Popup.vue";
import ToatmMessenger from "./components/base/ToastMessenger.vue";
import Loader from './components/base/Loader.vue'
export default {
  name: "App",
  components: {
    TheContainer,
    Popup,
    ToatmMessenger,
    Loader,
  },
  data() {
    return {
      // giá trị ẩn hoặc hiện toastMessenger
      isShowMes: false,
      mesText: "",
      mesType: "",
      // các biến truyền vào cho popup
      isShowPopup: false,
      popupText: "",
      popupType: "",
      listButton: "",
      modeForPopup: "",
      isShowLoader: false,
    };
  },
  created() {
    // Lắng nghe sự kiện show Popup và hiện thị lỗi
    this.emitter.on("showPopup", (a) => {
      console.log(a.split("###")[0]);
      console.log(a.split("###")[1]);
      console.log(a.split("###")[2]);
      this.isShowPopup = true;
      this.popupText = a.split("###")[0];
      this.popupType = a.split("###")[1];
      this.listButton = a.split("###")[2];
      this.modeForPopup = a.split("###")[3];
    });
    // //lắng nghe sự kiện closePopup để đóng popup
    // this.emitter.on("closePopup", (isShowPopup) => {
    //   this.isShowPopup = isShowPopup;
    // });
    //Lắng nghe sự kiện hiện toastMessenger
    this.emitter.on("showMes", (b) => {
      this.mesText = b.split("###")[0];
      this.mesType = b.split("###")[1];
      this.isShowMes = true;
    });
    this.emitter.on("showLoader",()=>{
      this.isShowLoader= true;
    });
    this.emitter.on("hideLoader",()=>{
      this.isShowLoader=false;
    })
  },
  methods: {
    /**
     * Xử lí sự kiện click vào 1 btn nào đó trên popup, dựa vào modeForPopup với btnClicked để xử lí sự kiện tương ứng
     * @param btnClicked
     * Author TrungTQ
     */
    popupOnConfirm(btnClicked) {
      switch (btnClicked) {
        case "x":
          if (this.modeForPopup == "delete") {
            this.emitter.emit("confirmToDelete");
            this.isShowPopup = false;
          } else if (this.modeForPopup == "saveChange") {
            this.emitter.emit("confirmToSaveChange");
            this.isShowPopup = false;
          }

          break;
        case "y":
          if (this.modeForPopup == "saveChange") {
            this.isShowPopup = false;
            this.emitter.emit("hideDialog");
          }
          break;
        case "z":
          if (this.modeForPopup == "saveChange") {
            this.isShowPopup = false;
          }
          break;
        case "t":
          if (this.modeForPopup == "messenger") {
            this.isShowPopup = false;
          }
          break;
        case "w":
          if (this.modeForPopup == "delete") {
            this.isShowPopup = false;
          }
          break;
        case "u":
          if (this.modeForPopup == "messenger") {
            this.isShowPopup = false;
          }
          break;
        default:
          break;
      }
    },
    /**
     * ẩn ToastMessenger
     * */
    hideMes() {
      this.isShowMes = false;
    },
  },
};
</script>

<style>
* {
  font-family: "GoogleSans-Regular";
}
@import url("./css/icon.css");

@font-face {
  font-family: "GoogleSans-Bold";
  src: url("./assets/fonts/notosans-bold.3ede5aff.woff2") format("opentype");
}

@font-face {
  font-family: "GoogleSans-Thin";
  src: url("./assets/fonts/notosans-semibold.df3e6dc4.woff2") format("opentype");
}

@font-face {
  font-family: "GoogleSans-Italic";
  src: url("./assets/fonts/notosans-italic.1c1aaac9.woff2") format("opentype");
}

@font-face {
  font-family: "GoogleSans-Regular";
  src: url("./assets/fonts/notosans-regular.2cb88a13.woff2") format("opentype");
}

[notvalid] {
  border: 1px solid #ff4747;
}

.border-red {
  border: 1px solid red !important;
}
* {
  font-family: "GoogleSans-Regular";
}
::-webkit-scrollbar {
  width: 10px;
  background-color: #f1f1f1;
}

::-webkit-scrollbar-thumb {
  background-color: #b8bcc3;
}

::-webkit-scrollbar-thumb:hover {
  background-color: #888888;
}

::-webkit-scrollbar:horizontal {
  height: 10px;
  background-color: #f1f1f1;
  z-index: 30000;
}

::-webkit-scrollbar-thumb:horizontal {
  background: #b8bcc3;
}

::-webkit-scrollbar-thumb:horizontal:hover {
  background: #888888;
}
</style>
