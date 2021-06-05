<template>
  <div class="headertitle">
    {{text}} 
  </div>  
</template>

<script>
export default {
  props: ["text"]
};
</script>

<style scoped>
.headertitle{
  padding: 20px;
  font-size: 32px;
  text-transform: capitalize;
  font-weight: bold;
  color: rgba(0,0,0, 0.75);
}
</style>
 