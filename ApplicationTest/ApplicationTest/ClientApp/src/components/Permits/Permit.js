import PermitTypeService from '../../services/PermitService';
import MomentHelper from '../../helpers/MomentHelper';
import PermitService from '../../services/PermitService';

export default {
  mounted() {
    this.getPermits();
  },

  data() {
    return {
      permits: [],
      isDeleteModalActive: false,
      permitIdSelected: 0,
    };
  },

  methods: {
    async getPermits() {
      const { data } = await PermitTypeService.getAll();
      this.permits = data;
    },

    formatDate(date) {
      return MomentHelper.formatDate(date);
    },

    async onConfirm() {
      try {
        await PermitService.delete(this.permitIdSelected);
        this.getPermits();
        this.$toastr.success(
          'Se ha eliminado el permiso correctamente',
          'Exito!'
        );
      } catch ({ response }) {
        this.$toastr.error(response.data, 'Ha ocurrido un error inesperado!');
      }
    },

    onCancel() {
      console.log('cancelado');
    },

    openDeleteModal(permitId) {
      this.isDeleteModalActive = true;
      this.permitIdSelected = permitId;
    },
  },
};
