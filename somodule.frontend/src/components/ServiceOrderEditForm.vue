
<template>
  <div class="container">
    <h4>Service Order</h4>

    <b-form @submit="onSubmit" v-if="show">
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
        <b-button type="submit" variant="primary">Save</b-button>
      </div>
    </b-form>
  </div>
</template>

<script>
import api from "../api/api";

export default {
  name: "ServiceOrderEditForm",
  props: ["serviceOrder"],
  data() {
    return {
      form: {
        serviceOrderNumber: this.serviceOrder[0].serviceOrderNumber,
        serviceDescription: this.serviceOrder[0].serviceDescription,
        customerCnpj: this.serviceOrder[0].customerCnpj,
        customerName: this.serviceOrder[0].customerName,
        professionalCpf: this.serviceOrder[0].professionalCpf,
        professionalName: this.serviceOrder[0].professionalName,
        executionDate: this.serviceOrder[0].executionDate,
        serviceValue: this.serviceOrder[0].serviceValue,
      },
      show: true,
    };
  },
  methods: {
    onSubmit(event) {
      event.preventDefault();

      api
        .put("/so", {
          id: this.serviceOrder[0].id,
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
          alert("Service Order succefully altered!");
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
};
</script>
