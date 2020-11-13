<template>
  <div>
    <table class="table table-sm">
      <thead>
        <tr class="bg-primary text-white">
          <th>Nombre del empleado</th>
          <th>Apellido del empleado</th>
          <th>Tipo de permiso</th>
          <th>Fecha del permiso</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="permit in permits" :key="permit.id">
          <td class="vertical-aling-center">
            {{ permit.employeeName }}
          </td>

          <td class="vertical-aling-center">
            {{ permit.employeeLastName }}
          </td>

          <td class="vertical-aling-center">
            {{ permit.permitType.description }}
          </td>

          <td>{{ formatDate(permit.date) }}</td>

          <td class="vertical-aling-center">
            <div class="row">
              <div class="col">
                <router-link :to="`/edit/${permit.id}`">
                  <button class="btn btn-outline-info mr-3">
                    <i class="far fa-edit"></i>
                  </button>
                </router-link>

                <button
                  class="btn btn-outline-danger"
                  @click="openDeleteModal(permit.id)"
                >
                  <i class="far fa-trash-alt"></i>
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

    <div v-if="!permits.length" class="text center">
      No hay permisos registradas
    </div>

    <md-dialog-confirm
      :md-active.sync="isDeleteModalActive"
      md-title="Esta seguro que desea eliminar este permiso?"
      md-content="Esta accion no se puede revertir"
      md-confirm-text="Eliminar"
      md-cancel-text="Cancelar"
      @md-confirm="onConfirm"
    />
  </div>
</template>

<script>
import Permit from "./Permit";

export default Permit;
</script>
