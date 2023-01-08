import axios from 'axios';

const apiClient = axios.create({
	baseURL: 'http://localhost:44313/api'
});

export default apiClient;
