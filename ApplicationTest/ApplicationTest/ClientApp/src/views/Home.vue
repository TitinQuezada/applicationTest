<template>
  <div class="row">
    <div class="col-12">
      <img alt="Vue logo" src="../assets/logo.png" />
    </div>

    <div class="col-12">
      <h3>Listado de permisos</h3>
    </div>

    <div class="col-12 mb-3">
      <router-link to="/create" tag="div">
        <button class="btn btn-outline-primary float-right">
          Crear Permiso
        </button>
      </router-link>
    </div>

    <div class="col-12">
      <Permit />
    </div>
  </div>
</template>

<script>
import Permit from "@/components/Permits/Permit.vue";

export default {
  name: "Home",
  components: {
    Permit,
  },
};
</script>
