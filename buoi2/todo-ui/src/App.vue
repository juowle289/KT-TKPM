<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'

const todos = ref([])
const loading = ref(true)

const loadTodos = async () => {
  try {
    const response = await axios.get(
      'http://localhost:5009/api/Todo'
    )

    todos.value = response.data
  } catch (error) {
    console.error(error)
  } finally {
    loading.value = false
  }
}

onMounted(() => {
  loadTodos()
})
</script>

<template>
  <div class="page">
    <div class="card">

      <div class="header">
        <div>
          <h1>Todo Dashboard</h1>
          <p>Manage your tasks efficiently</p>
        </div>

        <button class="add-btn">
          + New Task
        </button>
      </div>

      <div v-if="loading" class="loading">
        Loading todos...
      </div>

      <table v-else>
        <thead>
          <tr>
            <th>ID</th>
            <th>Title</th>
            <th>Is Completed</th>
          </tr>
        </thead>

        <tbody>
          <tr
            v-for="todo in todos"
            :key="todo.id"
          >
            <td>#{{ todo.id }}</td>

            <td class="title">
              {{ todo.title }}
            </td>

            <td>
              <span
                :class="
                  todo.isCompleted
                    ? 'status done'
                    : 'status pending'
                "
              >
                {{
                  todo.isCompleted
                    ? 'Completed'
                    : 'Pending'
                }}
              </span>
            </td>
          </tr>
        </tbody>
      </table>

    </div>
  </div>
</template>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  background: #f4f4f4;
  font-family: Inter, Arial, sans-serif;
  color: #111;
}

.page {
  min-height: 100vh;
  padding: 40px;
}

.card {
  max-width: 1100px;
  margin: auto;
  background: white;
  border-radius: 24px;
  padding: 32px;
  box-shadow:
    0 10px 30px rgba(0,0,0,0.08);
}

.header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 32px;
}

.header h1 {
  font-size: 32px;
  font-weight: 700;
  color: black;
}

.header p {
  margin-top: 8px;
  color: #666;
}

.add-btn {
  background: black;
  color: white;
  border: none;
  padding: 14px 22px;
  border-radius: 14px;
  font-size: 14px;
  font-weight: 600;
  cursor: pointer;
  transition: 0.2s;
}

.add-btn:hover {
  transform: translateY(-2px);
  opacity: 0.9;
}

table {
  width: 100%;
  border-collapse: collapse;
}

thead {
  background: #fafafa;
}

th {
  text-align: left;
  padding: 18px;
  font-size: 13px;
  color: #666;
  border-bottom: 1px solid #eee;
  text-transform: uppercase;
  letter-spacing: 1px;
}

td {
  padding: 20px 18px;
  border-bottom: 1px solid #f1f1f1;
}

tbody tr {
  transition: 0.2s;
}

tbody tr:hover {
  background: #fafafa;
}

.title {
  font-weight: 600;
  color: #111;
}

.status {
  padding: 8px 14px;
  border-radius: 999px;
  font-size: 13px;
  font-weight: 600;
}

.done {
  background: #e8f8ec;
  color: #1b7a34;
}

.pending {
  background: #fff4e5;
  color: #b26a00;
}

.loading {
  padding: 40px;
  text-align: center;
  color: #777;
  font-size: 15px;
}
</style>