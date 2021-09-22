<template>
  <div class="container">
    <h4>Service Order</h4>

    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-row>
        <b-col md="12" sm="12">
          <b-form-group label="Code:" label-for="serviceOrderNumber">
            <b-form-input
              id="serviceOrderNumber"
              v-model="form.serviceOrderNumber"
              placeholder="0001"
              required
            ></b-form-input>
          </b-form-group>
        </b-col>
      </b-row>

      <b-row>
        <b-col md="12" sm="12">
          <b-form-group label="Description:" label-for="serviceDescription">
            <b-form-input
              id="serviceDescription"
              v-model="form.serviceDescription"
              placeholder="Enter description or title"
              required
            ></b-form-input>
          </b-form-group>
        </b-col>
      </b-row>

      <b-row>
        <b-col md="12" sm="12">
          <b-form-group label="Value:" label-for="serviceValue">
            <b-form-input
              id="serviceValue"
              v-model="form.serviceValue"
              placeholder="1234,01"
              number
              step=".01"
              required
            ></b-form-input>
          </b-form-group>
        </b-col>
      </b-row>

      <b-row>
        <b-col md="12" sm="12">
          <b-form-group label="Execution Date:" label-for="executionDate">
            <b-form-datepicker
              id="executionDate"
              v-model="form.executionDate"
              placeholder="dd/mm/yyyy"
            >
            </b-form-datepicker>
          </b-form-group>
        </b-col>
      </b-row>

      <hr />
      <h4>Customer</h4>

      <b-row>
        <b-col md="12" sm="12">
          <b-form-group
            id="cpf"
            label="Customer Document:"
            label-for="customerCnpj"
          >
            <b-form-input
              id="customerCnpj"
              v-model="form.customerCnpj"
              placeholder="12.345.678/9012-34"
              required
            ></b-form-input>
          </b-form-group>
        </b-col>
      </b-row>
      <b-row>
        <b-col md="12" sm="12">
          <b-form-group
            id="customerName"
            label="Customer Name:"
            label-for="customerName"
          >
            <b-form-input
              id="customerName"
              v-model="form.customerName"
              placeholder="Enter name"
              required
            ></b-form-input>
          </b-form-group>
        </b-col>
      </b-row>

      <hr />
      <h4>Professional</h4>

      <b-row>
        <b-col md="12" sm="12">
          <b-form-group
            label="Professional Document:"
            label-for="professionalCpf"
          >
            <b-form-input
              id="professionalCpf"
              v-model="form.professionalCpf"
              placeholder="123.456.789-09"
              required
            ></b-form-input>
          </b-form-group>
        </b-col>
      </b-row>

      <b-row>
        <b-col md="12" sm="12">
          <b-form-group label="Professional Name:" label-for="professionalName">
            <b-form-input
              id="professionalName"
              v-model="form.professionalName"
              placeholder="Enter name"
              required
            ></b-form-input>
          </b-form-group>
        </b-col>
      </b-row>

      <div class="mt-3 d-flex justify-content-end">
        <b-button type="reset" variant="warning" class="mr-3">Clear</b-button>
        <b-button type="submit" variant="primary">Save</b-button>
      </div>
    </b-form>
  </div>
</template>

<script>
import api from "../api/api";

export default {
  name: "ServiceOrderForm",
  data() {
    return {
      form: {
        serviceOrderNumber: "",
        serviceDescription: "",
        customerCnpj: "",
        customerName: "",
        professionalCpf: "",
        professionalName: "",
        executionDate: "",
        serviceValue: "",
      },
      show: true,
    };
  },
  methods: {
    onSubmit(event) {
      event.preventDefault();

      api
        .post("/so", {
          serviceOrderNumber: this.form.serviceOrderNumber,
          serviceDescription: this.form.serviceDescription,
          customerCnpj: this.form.customerCnpj,
          customerName: this.form.customerName,
          professionalCpf: this.form.professionalCpf,
          professionalName: this.form.professionalName,
          executionDate: this.form.executionDate,
          serviceValue: this.form.serviceValue,
        })
        .then(() => {
          alert("Service Order succefully registered!");
        })
        .catch((error) => {
          console.log(error);
        });
    },
    onReset(event) {
      event.preventDefault();

      this.form.serviceOrderNumber = "";
      this.form.serviceDescription = "";
      this.form.customerCnpj = "";
      this.form.customerName = "";
      this.form.professionalCpf = "";
      this.form.professionalName = "";
      this.form.executionDate = "";
      this.form.serviceValue = "";

      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    },
  },
};
</script>
