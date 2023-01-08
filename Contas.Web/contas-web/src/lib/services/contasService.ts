import apiClient from './api';

export class ContasService {
	static async getContas() {
		return apiClient.get('/contas');
	}
}
