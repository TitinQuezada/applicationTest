import http from '../http-common';

class PermitService {
    baseUrl = 'api/permits';

    getAll() {
        return http.get(this.baseUrl);
    }

    get(id) {
        return http.get(`${this.baseUrl}/${id}`);
    }

    create(permit) {
        return http.post(this.baseUrl, permit);
    }

    update(permit) {
        return http.put(`${this.baseUrl}`, permit);
    }

    delete(id) {
        return http.delete(`${this.baseUrl}/${id}`);
    }

    deleteAll() {
        return http.delete(`${this.baseUrl}`);
    }
}

export default new PermitService();