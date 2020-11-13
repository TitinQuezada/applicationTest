import http from '../http-common';

class PermitTypeService {
    baseUrl = 'api/permitTypes';

    getAll() {
        return http.get(this.baseUrl);
    }

}

export default new PermitTypeService();