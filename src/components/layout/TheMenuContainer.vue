<template>
        <div class="menu-container">
            <div class="logo-container">
                <a href="https://amisapp.misa.vn/home" class="menu-container-option"></a>
                <a href="" class="logo">
                    <img src="../../assets/imgs/Logo_Module_TiengViet_White.66947422.svg" alt="img-icon">
                </a>
            </div>
            <div class="menu-list">
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip dashboard-icon"></div>
                        <div class="title-tooltip">Tổng quan</div>
                    </a>
                </div>
                <div class="tooltip">
                    <router-link to="/employee" class="tooltip-content ">
                        <div class="icon-tooltip cash-icon"></div>
                        <div class="title-tooltip">Tiền mặt</div>
                    </router-link>
                </div>
                <div class="tooltip">
                    <router-link to="/customer" class="tooltip-content">
                        <div class="icon-tooltip deposit-icon"></div>
                        <div class="title-tooltip">Tiền gửi</div>
                    </router-link>
                </div>
                <div class="tooltip">
                    <a class="tooltip-content">
                        <div class="icon-tooltip buy-icon"></div>
                        <div class="title-tooltip">Mua hàng</div>
                    </a>
                </div>
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip sell-icon"></div>
                        <div class="title-tooltip">Bán hàng</div>
                    </a>
                </div>
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip billmanage-icon"></div>
                        <div class="title-tooltip">Quản lý hóa đơn</div>
                    </a>
                </div>
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip warehouse-icon"></div>
                        <div class="title-tooltip">Kho</div>
                    </a>
                </div>
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip tool-icon"></div>
                        <div class="title-tooltip">Công cụ dụng cụ</div>
                    </a>
                </div>
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip fixedassets-icon"></div>
                        <div class="title-tooltip">Tài sản cố định</div>
                    </a>
                </div>
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip tax-icon"></div>
                        <div class="title-tooltip">Thuế</div>
                    </a>
                </div>
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip price-icon"></div>
                        <div class="title-tooltip">Giá thành</div>
                    </a>
                </div>
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip synthetic-icon"></div>
                        <div class="title-tooltip">Tổng hợp</div>
                    </a>
                </div>
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip budget-icon"></div>
                        <div class="title-tooltip">Ngân sách</div>
                    </a>
                </div>
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip report-icon"></div>
                        <div class="title-tooltip">Báo cáo</div>
                    </a>
                </div>
                <div class="tooltip">
                    <a href="" class="tooltip-content">
                        <div class="icon-tooltip finace-icon"></div>
                        <div class="title-tooltip">Phân tích tài chính</div>
                    </a>
                </div>

            </div>
        </div>
</template>

<script>
export default {
    
}
</script>

<style>
    .menu-container {
    display: flex;
    flex-direction: column;
    background-color: rgb(56, 57, 61);
    min-width: 178px;
}

.menu-container .logo-container {
    display: flex;
    flex-direction: row;
    height: 48px;
    background-color: rgb(56, 57, 61);
    justify-items: center;
    align-items: center;
}

.logo-container .menu-container-option {
    display: flex;
    width: 24px;
    height: 24px;
    margin-right: 10px;
    margin-left: 24px;
}

.logo-container .logo {
    display: flex;
    height: 32px;
    flex-grow: 2;
}

.menu-list {
    padding-top: 14px;
}

.menu-list .tooltip-content {
    display: flex;
    text-decoration: none;
    color: rgb(255, 255, 255);
    justify-items: center;
    align-items: center;
    font-size: 13px;
    padding-left: 16px;
    height: 42px;
    cursor: pointer;
}

.tooltip-content .icon-tooltip {
    height: 24px;
    width: 24px;
    margin-right: 10px;
    justify-items: center;
    align-items: center;
}

.tooltip-content .title-tooltip {
    /* font-weight: 400; */
    font-size: 13px;
    margin-left: -4px;
}

.router-link-active {
    background-color: #58595d;
    border-left: 6px solid rgb(44, 160, 28);
    box-sizing: border-box;
    font-weight: 700;
}

.router-link-active .icon-tooltip {
    position: relative;
    left: -6px;
}

.router-link-active .title-tooltip {
    position: relative;
    left: -6px;
}

.router-link-active .deposit-icon {
    background: url('../../assets/imgs/Sprites.64af8f61.svg') no-repeat -119px -1585px;
}

.router-link-active .cash-icon {
    background: url('../../assets/imgs/Sprites.64af8f61.svg') no-repeat -75px -1585px;
}

.menu-list .tooltip-content:hover {
    background-color: #58595d;
}
</style>