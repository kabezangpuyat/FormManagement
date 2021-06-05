<template>
  <div class="modal-form">
    <div class="title" v-if="isEdit">Edit User</div>
    <div class="title" v-else>New User</div>
    <div class="field">
      <label>Name</label>
      <input type="text" v-model="name" placeholder="User Name">
    </div>
    <div class="form-buttons">
      <button @click="hide">Cancel</button>
      <button @click="save">Save</button>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {
    // if (this.isEdit) {
    //   this.id = this.user.id;
    //   this.name = this.user.name;
    // }
  },
  props: ["isEdit", "user"],
  data() {
    return {
      id: null,
      name: ""
    };
  },
  methods: {
    async save() {
    //   let data = {
    //     // id: this.id,
    //     // name: this.name
    //   };

      if (this.isEdit) {
        // await this.$store.dispatch("campaigns/update", data);
      } else {
        // await this.$store.dispatch("campaigns/create", data);
      }
      this.$emit("close");
    },
    hide: function() {
      this.$emit("close");
    }
  }
};
</script>

<style scoped>
.field {
  display: flex;
  justify-content: flex-start;
  align-items: center;
  padding: 20px 0px;
}

.field > label {
  width: 100px;
}
.field > input[type="text"] {
  font-family: "Montserrat", sans-serif;
  width: 100%;
}
</style>
