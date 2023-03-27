<template>
  <div>
    <main class="box">
      <h2>Loan application</h2>
      <form @submit.prevent="onSubmit">
        <div class="inputBox">
          <label for="personalCode">Personal code</label>
          <input type="text" class="form-control" v-model="personalCode" placeholder="Enter your personal code" required/>
          <div v-if="personalCodeError" class="invalid-feedback">{{ personalCodeError }}</div>
        </div>
        <div class="inputBox">
          <label for="loanAmount">Loan amount</label>
          <input type="loanAmount" class="form-control" v-model="loanAmount" placeholder="Enter the loan amount" required/>
          <div v-if="loanAmountError" class="invalid-feedback">{{ loanAmountError }}</div>
        </div>
        <div class="inputBox">
          <label for="loanPeriod">Loan period</label>
          <input type="loanPeriod" class="form-control" v-model="loanPeriod" placeholder="Enter the loan period in months" required/>
          <div v-if="loanPeriodError" class="invalid-feedback">{{ loanPeriodError }}</div>
        </div>
        <button type="submit" class="btn btm primary">Submit application</button>
      </form>
      <div v-if="responseMessage" class="response">{{ responseMessage }}</div>
    </main>
    <footer>
    </footer>
  </div>
</template>


<script>
import axios from 'axios';
import { createApp, ref } from "vue";

export default {
  setup() {
    const personalCode = ref('');
    const loanAmount = ref(0);
    const loanPeriod = ref(0);
    const personalCodeError = ref(null);
    const loanAmountError = ref(null);
    const loanPeriodError = ref(null);
    const responseMessage = ref(null);

    const validatePersonalCode = () => {
      if (!personalCode.value) {
        personalCodeError.value = 'Personal code is required';
      } else if (personalCode.value.length !== 11) {
        personalCodeError.value = 'Personal code must be 11 digits';
      } else {
        personalCodeError.value = null;
      }
    };

    const validateLoanAmount = () => {
      if (!loanAmount.value) {
        loanAmountError.value = 'Loan amount is required';
      } else if (loanAmount.value < 2000) {
        loanAmountError.value = 'Loan amount must be at least 2000';
      } else if (loanAmount.value > 10000) {
        loanAmountError.value = 'Loan amount cannot exceed 10000';
      } else {
        loanAmountError.value = null;
      }
    };

    const validateLoanPeriod = () => {
      if (!loanPeriod.value) {
        loanPeriodError.value = 'Loan period is required';
      } else if (loanPeriod.value < 12) {
        loanPeriodError.value = 'Loan period must be at least 12 months';
      } else if (loanPeriod.value > 60) {
        loanPeriodError.value = 'Loan period cannot exceed 60 months';
      } else {
        loanPeriodError.value = null;
      }
    };

    const onSubmit = () => {
      validatePersonalCode();
      validateLoanAmount();
      validateLoanPeriod();

      if (
        personalCodeError.value ||
        loanAmountError.value ||
        loanPeriodError.value
      ) {
        responseMessage.value = null;
        return;
      }

      axios.post('https://localhost:7038/api/Person?personalCode=' + personalCode.value 
          + '&loanAmount=' + loanAmount.value 
          + '&loanPeriod=' + loanPeriod.value, 
          )
      .then(response => {
        responseMessage.value = response.data;
      });
    };

    return {
      personalCode,
      loanAmount,
      loanPeriod,
      personalCodeError,
      loanAmountError,
      loanPeriodError,
      onSubmit,
      responseMessage
    };
  }
};
</script>

<style scoped>
* {
box-sizing: border-box;
}
body {
font-family: sans-serif;
height: 100vh;
margin: 0;
padding: 0;
background-color: blue;
}
header {
display: none;
}
.box {
background-color: rgba(0, 0, 0, 0.8);
border-radius: 10px;
box-shadow: 0 15px 25px rgba(0, 0, 0, 0.8);
margin: auto auto;
padding: 40px;
position: absolute;
top: 50%;
left: 50%;
transform: translate(-50%, -50%);
text-align: left;
}
.box h2 {
margin: 0 0 30px 0;
padding: 0;
color: #fff;
text-align: center;
}
.box .inputBox label {
color: #fff;
}
.box .inputBox input {
background: transparent;
border: none;
border-bottom: 1px solid #fff;
color: #fff;
font-size: 18px;
letter-spacing: 2px;
margin-bottom: 30px;
outline: none;
padding: 10px 0;
width: 100%;
}
.box input[type="submit"], .box button[type="submit"], a.button {
font-family: sans-serif;
background: #03a9f4;
font-size: 11px;
border: none;
border-radius: 5px;
color: #fff;
cursor: pointer;
font-weight: 600;
padding: 10px 20px;
letter-spacing: 2px;
outline: none;
text-transform: uppercase;
text-decoration: none;
margin: 2px 10px 2px 0;
display: inline-block;
}
.box input[type="submit"]:hover, .box button[type="submit"]:hover, a.button:hover {
opacity: 0.8;
}

.invalid-feedback {
  color: red;
  margin-bottom: 5px;
}
.response {
  color: white;
  margin-top: 25px;
}

</style>