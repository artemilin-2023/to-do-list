export default class BoardApi {
  constructor(axiosInstance) {
    this.api = axiosInstance;
  }

  getAll(search, tags, dateRange, boardType) {
    this.api.get("/boards", {
      params: {
        search: search,
        tags: tags,
        dateFrom: dateRange[0],
        dateTo: dateRange[1],
        boardType: boardType,
      },
    });
  }

  async get(id) {
    return await this.api.get(`/boards/${id}`);
  }

  async delete(id) {
    console.log(`delete board: /boards/${id}`);
    return await this.api.delete(`/boards/${id}`);
  }

  post(title, description, tags, teammates) {
    return;
  }

  patch(id, title, description, tags, teammates) {
    return;
  }
}
