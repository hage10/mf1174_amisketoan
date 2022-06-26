<template>
    <div class="container">
        <TheMenuContainer/>
        <TheAreaContent/>
    </div>
</template>

<script>
import TheMenuContainer from './TheMenuContainer.vue';
import TheAreaContent from './TheAreaContent.vue';
export default {
  name: 'TheContainer',
  components: {
    TheMenuContainer,
    TheAreaContent,
}
}
</script>


<style>
* {
    margin: 0;
    box-sizing: border-box;
    text-decoration-color: initial;
    margin: 0;
    padding: 0;
    font-family: GoogleSans-Regular;
    font-size: 13px;
}

.container {
    display: flex;
    flex-direction: row;
    width: 100%;
    height: 100vh;
    position: fixed;
}
</style>