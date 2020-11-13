<template>
  <div class="container">
    <div className="row">
      <div className="col-12">
        <table className="table table-sm">
          <thead>
            <tr className="bg-primary text-white">
              <th>Nombre del empleado</th>
              <th>Apellido del empleado</th>
              <th>Tipo de permiso</th>
              <th>Fecha del permiso</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="permit in permits" :key="permit.id">
              <td className="vertical-aling-center">
                {{ permit.employeeName }}
              </td>

              <td className="vertical-aling-center">
                {{ permit.employeeLastName }}
              </td>

              <td className="vertical-aling-center">
                {{ permit.permitType.description }}
              </td>

              <td>{{ formatDate(permit.date) }}</td>

              <td className="vertical-aling-center">
                <div className="row">
                  <div className="col">
                    <router-link :to="`/edit/${permit.id}`">
                      <button className="btn btn-outline-info mr-3">
                        <i className="far fa-edit"></i>
                      </button>
                    </router-link>

                    <button className="btn btn-outline-danger">
                      <i className="far fa-trash-alt"></i>
                    </button>
                  </div>
                </div>
              </td>
            </tr>

            <tr>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import PermitService from "../services/PermitService";
import MomentHelper from "../helpers/MomentHelper";

export default {
  name: "ajso",
  props: {
    msg: String,
  },

  data() {
    return { permits: [] };
  },
  methods: {
    GetAllPermits() {
      PermitService.getAll()
        .then((response) => {
          this.permits = response.data;
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },

    formatDate(date) {
      return MomentHelper.formatDate(date);
    },
  },

  mounted() {
    this.GetAllPermits();
  },
};
</script>


<style scoped>
</style>
