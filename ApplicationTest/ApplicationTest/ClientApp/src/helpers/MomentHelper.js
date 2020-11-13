import moment from 'moment'

class MomentHelper {
    formatDate(date) {
        return moment(String(date)).format('MM/DD/YYYY');
    }

    getDate() {
        return moment().format('YYYY-DD-MM');
    }

    ValidateDate(date) {
        return moment(String(date)).isValid();
    }
}

export default new MomentHelper();