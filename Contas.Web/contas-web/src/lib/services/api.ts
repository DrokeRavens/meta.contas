import axios from 'axios';

const apiClient = axios.create({
	baseURL: 'https://localhost:44313/api'
});

export default apiClient;
