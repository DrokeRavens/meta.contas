import type { CreateContaDto } from '$lib/models/createContaDto';
import apiClient from './api';

class ContasService {
	async createConta(createContaModel: CreateContaDto) {
		return apiClient.post('/contas', createContaModel);
	}
	async getContas() {
		return apiClient.get('/contas');
	}
}

export const contasService = new ContasService();
