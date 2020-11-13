<template lang="html">
  <section class="container">
    <h2>Actualizacion de permiso</h2>
    <form class="row p-5">
      <div class="col-6 form-group">
        <label>Nombre del empleado</label>
        <input v-model="employeeName"
          type="text"
          class="form-control"
          placeholder="Nombre del empleado"
        />
      </div>
      <div class="col-6 form-group">
        <label>Apellido del empleado</label>
        <input v-model="employeeLastName"
          type="text"
          class="form-control"
          placeholder="Apellido del empleado"
        />
      </div>

      <div class="col-6 form-group">
    <label for="exampleFormControlSelect1">Permiso</label>
    <select v-model="permitType" class="form-control">
      <option disabled>Seleccione un tipo de permiso</option>
      <option v-for="permitType in permitTypes" :key="permitType.id" v-bind:value="permitType">{{permitType.description}}</option>
    </select>
  </div>

      <div class="col-6 form-group">
        <label>Fecha</label>
        <input v-model="date"
          type="date"
          class="form-control"
        />
      </div>

      <div class="col-12 text-center mb-3" v-if="errorMessage">
          <small class="text-danger">{{errorMessage}}</small>
      </div>

      <div class="col-12">
      <button type="button" class="btn btn-primary btn-block" v-on:click="updatePermit">Actualizar</button>
      <router-link to="/">
       <button type="button" class="btn btn-danger btn-block mt-3">Cancelar</button>
      </router-link>
      </div>
    
    </form>
  </section>
</template>

<script lang="js">
import MomentHelper from "../helpers/MomentHelper.js";
import PermitService from "../services/PermitService";
import PermitTypeService from "../services/PermitTypeService.js";

export default {
  name: "src-components-edit-permit",
  props: [],
  mounted() {
    this.getPermit();
    this.getPermitTypes();
  },
  data() {
    return {
      employeeName: "",
      employeeLastName: "",
      permitType: { id: 0, description: "licencia" },
      date: MomentHelper.getDate(),
      permitTypes: [],
      errorMessage:''
    };
  },
  methods: {
    async getPermit() {
      const permit = await PermitService.get(this.$route.params.id);
      const { employeeName, employeeLastName, permitType, date } = permit.data;
      this.employeeName = employeeName;
      this.employeeLastName = employeeLastName;
      this.permitType = permitType;
      this.date = date;
    },

    async getPermitTypes() {
      const permitTypes = await PermitTypeService.getAll();
      this.permitTypes = permitTypes.data;
    },

    validateForm() {
      if (!this.employeeName) {
        this.errorMessage = 'El nombre del empleado es requerido';

        return false;
      }

      if (!this.employeeLastName) {
        this.errorMessage = 'El apellido del empleado es requerido';

        return false;
      }

      if (!MomentHelper.ValidateDate(this.date)) {
        this.errorMessage = 'La fecha no es valida';

        return false;
      }

        this.errorMessage = '';

      return true;
    },

    async updatePermit()
    {
      if(this.validateForm())
      {
        const permit = {
          id:this.$route.params.id,
          employeeName: this.employeeName,
          employeeLastName: this.employeeLastName,
          permitType: this.permitType.id,
          date: this.date
        }

        await PermitService.update(permit);
        this.$router.push('/')
      }
    }
  },
  computed: {},
};
</script>

<style scoped lang="css">
</style>
