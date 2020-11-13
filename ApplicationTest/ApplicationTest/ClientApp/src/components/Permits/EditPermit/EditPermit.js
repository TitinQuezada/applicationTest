import MomentHelper from '../../../helpers/MomentHelper';
import PermitService from '../../../services/PermitService';
import PermitTypeService from '../../../services/PermitTypeService';

export default {
  mounted() {
    this.getPermitTypes();
    this.getPermit();
  },

  data() {
    return {
      employeeName: '',
      employeeLastName: '',
      permitType: {},
      date: MomentHelper.getDate(),
      permitTypes: [],
      errorMessage: '',
      isLoading: false,
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

    async updatePermit() {
      if (this.validateForm()) {
        try {
          this.isLoading = true;

          const permit = {
            id: this.$route.params.id,
            employeeName: this.employeeName,
            employeeLastName: this.employeeLastName,
            permitType: this.permitType.id,
            date: this.date,
          };

          await PermitService.update(permit);
          this.isLoading = false;

          this.$toastr.success(
            'Se ha actualizado el permiso correctamente',
            'Exito!'
          );
        } catch ({ response }) {
          this.isLoading = false;
          this.$toastr.error(response.data, 'Ha ocurrido un error inesperado!');
        }
      }
    },
  },
};
