import MomentHelper from '../../../helpers/MomentHelper';
import PermitService from '../../../services/PermitService';
import PermitTypeService from '../../../services/PermitTypeService';

export default {
  mounted() {
    this.getPermitTypes();
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

      if (!this.permitType.id) {
        this.errorMessage = 'Debe seleccionar un tipo de permiso';

        return false;
      }

      this.errorMessage = '';

      return true;
    },

    async createPermit() {
      if (this.validateForm()) {
        try {
          this.isLoading = true;

          const permit = {
            employeeName: this.employeeName,
            employeeLastName: this.employeeLastName,
            permitType: this.permitType.id,
            date: this.date,
          };

          await PermitService.create(permit);
          this.isLoading = false;

          this.cleanForm();

          this.$toastr.success(
            'Se ha creado el permiso correctamente',
            'Exito!'
          );
        } catch ({ response }) {
          this.isLoading = false;
          this.$toastr.error(response.data, 'Ha ocurrido un error inesperado!');
        }
      }
    },

    cleanForm() {
      this.employeeName = '';
      this.employeeLastName = '';
      this.permitType = {};
      this.date = MomentHelper.getDate();
    },
  },
};
