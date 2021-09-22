<template>
  <div>
    <div class="d-flex justify-content-end">
      <b-button
        class="my-2 mx-1"
        id="show-btn"
        @click="$bvModal.show('forms-modal')"
        variant="primary"
        size="sm"
        >New</b-button
      >
      <b-button
        class="my-2 mx-1"
        id="show-btn"
        @click="$bvModal.show('forms-edit-modal')"
        variant="warning"
        size="sm"
        v-show="selected"
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

    <b-modal id="forms-modal" hide-footer><service-order-form /></b-modal>

    <b-modal id="forms-edit-modal" hide-footer
      ><service-order-edit-form :serviceOrder="selected"
    /></b-modal>
  </div>
</template>

<script>
import api from "./api/api";
import ServiceOrderForm from "./components/ServiceOrderForm.vue";
import ServiceOrderEditForm from "./components/ServiceOrderEditForm.vue";

export default {
  components: {
    ServiceOrderForm,
    ServiceOrderEditForm,
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
          key: "customerName",
          label: "Customer Name",
          sortable: true,
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
        {
          key: "executionDate",
          label: "Execution Date",
          sortable: true,
          formatter: (value) => {
            return new Date(value).toLocaleDateString("pt-BR");
          },
        },
      ],
    };
  },
  created() {
    this.getServiceOrders();
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
    },
  },
};
</script>