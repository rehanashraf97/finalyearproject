<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Api_model extends CI_Model {

	public function createUser($userInfo)
	{
		if ($this->db->insert('users',$userInfo)) {
			return true;
		}
		return false;
	}

	public function createBrand($createBrand)
	{
		if ($this->db->insert('brands',$createBrand)) {
			return true;
		}
		return false;
	}

	public function checkUserExist($email, $password)
	{
		$this->db->select('*');
		$this->db->where('email',$email);
		$this->db->where('password',$password);
		$this->db->from('users');
		$q = $this->db->get();
		if ($q->num_rows() > 0 ) {
			foreach ($q->result() as $row ) {
				$data[] = $row;
			}
			return $data;
		}
		return false;

	}

	public function getBrand($user_id)
	{
		$this->db->select('*');
		$this->db->where('u_id',$user_id);
		$this->db->from('brands');
		$q = $this->db->get();
		if ($q->num_rows() > 0 ) {
			foreach ($q->result() as $row ) {
				$data[] = $row;
			}
			return $data;
		}
		return false;

	}

}

/* End of file Api_model.php */
/* Location: ./application/models/Api_model.php */