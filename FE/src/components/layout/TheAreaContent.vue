<template>
    <div class="area-content">
        <TheHeader/>
        <TheMainContent/>
    </div>
</template>

<script>
import TheHeader from './TheHeader.vue';
import TheMainContent from './TheMainContent.vue';
export default {
  name: 'TheContainer',
  components: {
    TheHeader,TheMainContent
}
}
</script>

<style>
.area-content {
    display: flex;
    flex-direction: column;
    flex-grow: 2;
    width: 42%;
}

.area-content .main-content {
    background-color: rgb(236, 238, 241);
    flex-grow: 2;
}

.area-content .header {
    display: flex;
    background-color: #fff;
    justify-content: space-between;
    align-items: center;
    padding-bottom: 8px;
    padding-top: 8px;
}

.main-content {
    display: flex;
    max-width: 100%;
    flex-direction: column;
    padding-left: 20px;
    padding-right: 20px;
}

.main-content .header-content {
    display: flex;
    justify-content: space-between;
    height: 36px;
    align-items: stretch;
    margin-top: 24px;
    margin-bottom: 24px;
}

.header-content .title-content {
    display: flex;
    font-size: 24px;
    font-weight: 700;
    color: #111;
    line-height: 36px;
}
</style>