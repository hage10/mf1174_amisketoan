<template>
    <div class="header">
                <div class="company">
                    <div class="three-stripes"></div>
                    <div class="main-company">
                        <div class="company-name">CÔNG TY TNHH SẢN XUẤT - THƯƠNG MẠI - DỊCH VỤ QUI PHÚC </div>
                        <div class="down-arrow-icon"></div>
                    </div>
                </div>
                <div class="user">
                    <div class="rell-icon"></div>
                    <div class="user-main">
                        <div class="avatar-user"></div>
                        <div class="user-name">Nguyễn Văn Mạnh</div>
                        <div class="down-arrow-icon-avatar"></div>
                    </div>
                </div>
            </div>
</template>

<script>
export default {
    
}
</script>

<style>
.company {
    display: flex;
    align-items: center;
}

.company .main-company {
    display: flex;
    cursor: pointer;
}

.company .company-name {
    max-width: 500px;
    font-weight: 600;
    font-size: 14px;
    padding-left: 10px;
    height: 15px;
    white-space: nowrap;
}

.company .three-stripes {
    height: 24px;
    width: 24px;
    margin: 0 10px 0;
    cursor: pointer;
}

.down-arrow-icon {
    height: 14px;
    width: 14px;
    margin: 0 10px 0;
}

.user {
    display: flex;
    align-items: center;
    padding-right: 20px;
}

.user .user-main {
    display: flex;
    align-items: center;
    cursor: pointer;
}

.user .rell-icon {
    height: 24px;
    width: 24px;
    margin: 0 10px 0;
}

.user .avatar-user {
    height: 32px;
    width: 32px;
    background-color: black;
    margin: 0 10px 0;
}
</style>