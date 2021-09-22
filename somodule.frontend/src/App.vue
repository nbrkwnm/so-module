<template>
  <div>
    <div class="d-flex justify-content-end">
      <b-button
        class="my-2 mx-1"
        id="show-btn"
        @click="
          $bvModal.show('forms-modal');
          setNew(true);
        "
        variant="primary"
        size="sm"
        >New</b-button
      >
      <b-button
        class="my-2 mx-1"
        id="show-btn"
        @click="
          $bvModal.show('forms-modal');
          setNew(false);
        "
        variant="warning"
        size="sm"
        >Edit</b-button
      >
      <b-button
        class="my-2 mx-1"
        id="delete-btn"
        variant="danger"
        size="sm"
        @click="deleteServiceOrder"
        >Delete</b-button
      >
    </div>
    <b-table
      striped
      hover
      :items="serviceOrders"
      :fields="fields"
      selectable
      select-mode="single"
      @row-selected="onRowSelected"
    >
    </b-table>

    <b-modal id="forms-modal" hide-footer
      ><service-order-forms :serviceOrder="selected" :isNew="isNew"
    /></b-modal>
  </div>
</template>

<script>
import api from "./api/api";
import ServiceOrderForms from "./components/ServiceOrderForms.vue";

export default {
  components: {
    ServiceOrderForms,
  },
  data() {
    return {
      show: true,
      selected: null,
      isNew: false,
      serviceOrders: [],
      fields: [
        {
          key: "serviceOrderNumber",
          label: "Service Order",
          sortable: true,
        },
        {
          key: "serviceDescription",
          label: "Description",
          sortable: true,
        },
        {
          key: "customerCnpj",
          label: "Customer Document",
          sortable: true,
        },
        {
          key: "customerName",
          label: "Customer Name",
          sortable: true,
        },
        {
          key: "professionalCpf",
          label: "Professional Document",
          sortable: true,
        },
        {
          key: "executionDate",
          label: "Execution Date",
          sortable: true,
          formatter: (value) => {
            return new Date(value).toLocaleDateString("pt-BR");
          },
        },
        {
          key: "serviceValue",
          label: "Value",
          sortable: true,
          formatter: (value) =>
            value.toLocaleString("pt-BR", {
              style: "currency",
              currency: "BRL",
            }),
        },
      ],
    };
  },
  created() {
    this.getServiceOrders();
    console.log(this.serviceOrders);
  },
  methods: {
    getServiceOrders() {
      api
        .get("/so")
        .then((res) => {
          this.serviceOrders = res.data;
        })
        .catch((error) => {
          console.log(error);
        });
    },
    onRowSelected(item) {
      this.selected = item;
      console.log(this.selected[0].id);
    },
    deleteServiceOrder() {
      console.log(this.selected);
      api
        .delete("/so/" + this.selected[0].id)
        .then(() => {
          alert("Service Order succefully deleted!");
        })
        .catch((error) => {
          console.log(error);
        });
    },
    setNew(value) {
      this.isNew = value;
      console.log(this.isNew);
    },
  },
};
</script>