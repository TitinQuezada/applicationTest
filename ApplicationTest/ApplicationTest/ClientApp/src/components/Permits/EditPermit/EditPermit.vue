<template>
  <section class="container">
    <h2>Actualizacion de permiso</h2>
    <form class="row p-5">
      <div class="col-6 form-group">
        <label>Nombre del empleado</label>
        <input
          v-model="employeeName"
          type="text"
          class="form-control"
          placeholder="Nombre del empleado"
          maxlength="30"
        />
      </div>
      <div class="col-6 form-group">
        <label>Apellido del empleado</label>
        <input
          v-model="employeeLastName"
          type="text"
          class="form-control"
          placeholder="Apellido del empleado"
          maxlength="30"
        />
      </div>

      <div class="col-6 form-group">
        <label for="exampleFormControlSelect1">Permiso</label>
        <select v-model="permitType" class="form-control">
          <option disabled>Seleccione un tipo de permiso</option>
          <option
            v-for="permitType in permitTypes"
            :key="permitType.id"
            v-bind:value="permitType"
          >
            {{ permitType.description }}
          </option>
        </select>
      </div>

      <div class="col-6 form-group">
        <label>Fecha</label>
        <input v-model="date" type="date" class="form-control" />
      </div>

      <div class="col-12 text-center mb-3" v-if="errorMessage">
        <small class="text-danger">{{ errorMessage }}</small>
      </div>

      <div class="col-12">
        <button
          type="button"
          class="btn btn-primary btn-block"
          v-on:click="updatePermit"
          :disabled="isLoading"
        >
          <span v-if="!isLoading">Actualizar</span>

          <div
            v-if="isLoading"
            class="spinner-border spinner-border-sm text-light"
            role="status"
          >
            <span class="sr-only">Loading...</span>
          </div>
        </button>
        <router-link to="/" tag="div">
          <button
            type="button"
            class="btn btn-danger btn-block mt-3"
            :disabled="isLoading"
          >
            Salir
          </button>
        </router-link>
      </div>
    </form>
  </section>
</template>

<script>
import EditPermit from "./EditPermit";

export default EditPermit;
</script>