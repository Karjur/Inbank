<script>
import LoanApplication from './components/LoanApplication.vue';
export default {
  name: 'App',
  components: {
    LoanApplication,
  },
};
</script>

<template>
  <div class="container">
  <div class="row">
    <div class="col-md-12">
      <loanApplication></loanApplication>
    </div>
  </div>
  </div>
</template>

<style>
#app {
  font-family: Arial, Helvetica, sans-serif;
  text-align: center;
  margin-top: 60px;
}
body {
  background-color: rgba(28, 27, 25, 0.8);
  
}
</style>
